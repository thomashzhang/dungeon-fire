using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultilaneShooter : Shooter
{
    private LevelController levelController;
    public SpriteRenderer Body { get; set; }
    private void Awake()
    {
        Body = GetComponentInChildren<SpriteRenderer>();
    }
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
