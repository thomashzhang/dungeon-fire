using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Defender
{
    [SerializeField] GameObject projectile, projectilePosition;
    private AttackerSpawner laneAttackerSpawner;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        SetLane();
        animator = GetComponent<Animator>();
    }

    private void SetLane()
    {
        var attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var attackerSpawner in attackerSpawners)
        {
            var close = Math.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (close)
            {
                laneAttackerSpawner = attackerSpawner;
            }
            break;
            // This assumes only one attacker spawner per lane
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (laneAttackerSpawner.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }

    public void Fire()
    {
        Instantiate(projectile, projectilePosition.transform.position, projectilePosition.transform.rotation);
    }
}
