using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiProjectileMultilaneShooter : MultilaneShooter
{
    [SerializeField] GameObject[] additionalProjectilePositions;

    public override void Fire()
    {
        base.Fire();
        foreach (var additionalProjectilePosition in additionalProjectilePositions)
        {
            var createdProjectile = Instantiate(projectile, additionalProjectilePosition.transform.position, additionalProjectilePosition.transform.rotation);
            createdProjectile.transform.parent = projectileParent.transform;
        }
    }

}
