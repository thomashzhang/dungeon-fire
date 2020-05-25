using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : Health
{
    // TODO: make this an array to support different number of damage levels
    [SerializeField] Sprite damageSprite1;
    [SerializeField] Sprite damageSprite2;
    private SpriteRenderer childSpriteRendererReference;

    protected override void Start()
    {
        // Enable or disabled walls based on whether the user bought them
        var walls = PlayerPrefsManager.Walls;
        if (walls <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            startingHealth = walls;
        }
        base.Start();
        childSpriteRendererReference = GetComponentInChildren<SpriteRenderer>();
    }
    public override void DealDamage(int damage)
    {
        base.DealDamage(damage);
        if (damageSprite1 != null && damageSprite2 != null)
        {
            UpdateDamageSprite();
        }
    }

    private void UpdateDamageSprite()
    {
        if ((currentHealth/(float)startingHealth) <= (1/3f))
        {
            if (childSpriteRendererReference.sprite != damageSprite2)
            {
                childSpriteRendererReference.sprite = damageSprite2;
            }
        }
        else if ((currentHealth/(float)startingHealth) <= (2/3f))
        {
            if (childSpriteRendererReference.sprite != damageSprite1)
            {
                childSpriteRendererReference.sprite = damageSprite1;
            }
        }
    }
}
