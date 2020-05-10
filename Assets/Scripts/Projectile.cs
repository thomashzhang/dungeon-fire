using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;
    [SerializeField] Sprite collisionSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
