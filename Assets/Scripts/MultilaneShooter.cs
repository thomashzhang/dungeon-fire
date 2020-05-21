using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultilaneShooter : Shooter
{
    private LevelController levelController;
    protected override void Start()
    {
        base.Start();
        levelController = FindObjectOfType<LevelController>();

    }
    protected override bool IsAttackerInLane()
    {
        return levelController.AttackerCount > 0;
    }
}
