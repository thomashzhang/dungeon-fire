using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int startingHealth = 5;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject deathSFX;
    protected int currentHealth;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void DealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DeathHandler();
        }
    }

    public void DeathHandler()
    {
        TriggerDeathSFX();
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathSFX()
    {
        if (deathSFX != null)
        {
            var deathSFXObject = Instantiate(deathSFX, transform.position, transform.rotation);
            Destroy(deathSFXObject, 1f);
        }
    }

    private void TriggerDeathVFX()
    {
        if (deathVFX != null)
        {
            var deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 1f);
        }
    }
}
