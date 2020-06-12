using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultilaneProjectile : Projectile
{
    Attacker targetAttacker;
    Vector2 targetAttackerLastPosition;
    bool targetAttackerFound = false;
    bool projectileNeutralized;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        projectileNeutralized = false;
        CalculateClosestAttackerToTarget();
        RotateTowardsAttacker();
    }

    private void RotateTowardsAttacker()
    {
        if (targetAttackerLastPosition != null)
        {
            // Rotate arrow towards attacker (see https://answers.unity.com/questions/1350050/how-do-i-rotate-a-2d-object-to-face-another-object.html)
            float angle = Mathf.Atan2(targetAttackerLastPosition.y - transform.position.y, targetAttackerLastPosition.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private void CalculateClosestAttackerToTarget()
    {
        try
        {
            var attackers = FindObjectsOfType<Attacker>();
            // Where filters out attackers that are behind the projectile at spawn time
            // Aggregate acts as a .Min with a key where we're grabbing the minimum position x
            targetAttacker = attackers
                .Where(attacker => attacker.transform.position.x > transform.position.x)
                .DefaultIfEmpty()
                .OrderBy(attacker => (attacker.transform.position - transform.position).sqrMagnitude)
                .FirstOrDefault();
            if (targetAttacker != null)
            {
                targetAttackerLastPosition = targetAttacker.transform.position;
                targetAttackerFound = true;
            }
        }
        catch
        {
            targetAttackerFound = false;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (targetAttackerFound)
        {
            if (firstFrame)
            {
                firstFrame = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = inFlightSprite;
            }
            MoveTowardsAttacker(targetAttacker);
        }
        else
        {
            base.Update();
        }
    }

    private void MoveTowardsAttacker(Attacker targetAttacker)
    {
        if (targetAttacker != null)
        {
            // TODO: Make homing arrows an upgrade!
            // If target attacker isn't dead, simply set the target position to be where the attacker is
            // targetAttackerLastPosition = targetAttacker.transform.position;

            //// Rotate arrow towards attacker (see https://answers.unity.com/questions/1350050/how-do-i-rotate-a-2d-object-to-face-another-object.html)
            //float angle = Mathf.Atan2(targetAttackerLastPosition.y - transform.position.y, targetAttackerLastPosition.x - transform.position.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            // If the attacker is dead, don't change projectile position, but do make sure the projectile is destoryed after it reaches its destination and loses its ability to damage attacker
            if (Vector2Equals(targetAttackerLastPosition, transform.position))
            {
                projectileNeutralized = true;
                Destroy(gameObject, 3);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, targetAttackerLastPosition, speed * Time.deltaTime);
    }

    private bool Vector2Equals(Vector2 first, Vector2 second)
    {
        return Math.Abs(first.y - second.y) <= Mathf.Epsilon && Math.Abs(first.x - second.x) < Mathf.Epsilon;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!projectileNeutralized)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}
