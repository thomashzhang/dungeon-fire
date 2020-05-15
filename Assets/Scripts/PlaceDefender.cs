﻿using System;
using UnityEngine;

public class PlaceDefender : MonoBehaviour
{
    private Defender defender;
    private GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (defenderParent == null)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        CreateDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }

    private Vector2 GetSquareClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        worldPos.x = (float) Math.Round(worldPos.x, 0);
        worldPos.y = (float) Math.Round(worldPos.y, 0);
        return worldPos;

    }

    private void CreateDefender(Vector2 position)
    {
        if (defender != null)
        {
            if (defender.CreateDefenderCrystalCost())
            {
                var spwanedDefender = Instantiate(defender, position, Quaternion.identity);
                spwanedDefender.transform.parent = defenderParent.transform;
            }
        }
    }
}
