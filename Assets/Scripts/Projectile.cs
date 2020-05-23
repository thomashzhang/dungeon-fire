using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed = 4f;
    [SerializeField] int damage = 1;
    [SerializeField] protected Sprite collisionSprite;
    [SerializeField] protected Sprite inFlightSprite;

    protected bool firstFrame;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        firstFrame = true;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (firstFrame)
        {
            firstFrame = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = inFlightSprite;
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //transform.Rotate(100f * Time.deltaTime, 0f, 0f);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>() != null)
        {
            collision.GetComponent<Health>()?.DealDamage(damage);
            if (collisionSprite != null)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = collisionSprite;
                Destroy(gameObject, 0.1f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
