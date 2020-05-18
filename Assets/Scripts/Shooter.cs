using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Defender
{
    [SerializeField] GameObject projectile, projectilePosition;
    private AttackerSpawner laneAttackerSpawner;
    private Animator animator;
    private GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetLane();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (projectileParent == null)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
                break;
            }
            // This assumes only one attacker spawner per lane
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
        var createdProjectile = Instantiate(projectile, projectilePosition.transform.position, projectilePosition.transform.rotation);
        createdProjectile.transform.parent = projectileParent.transform;
    }
}
