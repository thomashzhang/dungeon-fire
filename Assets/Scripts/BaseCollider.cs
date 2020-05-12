using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private LivesDisplay livesDisplay;
    // Start is called before the first frame update
    void Start()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>() != null)
        {
            livesDisplay.AttackerReachedBase();
            Destroy(collision.gameObject);
        }
    }
}
