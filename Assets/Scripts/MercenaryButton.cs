using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryButton : SelectButton
{
    [SerializeField] Mercenary defenderPrefab;
    // Start is called before the first frame update
    private void Start()
    {
        UpdateButtonCost();
    }

    protected virtual void UpdateButtonCost()
    {
        var costText = GetComponentInChildren<TextMeshProUGUI>();
        if (costText == null)
        {
            Debug.LogError($"{name} has no cost text");
        }
        else
        {
            costText.text = defenderPrefab.GetCrystalCost().ToString();
        }

    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        FindObjectOfType<PlaceMercenary>().SetSelectedDefender(defenderPrefab);
    }
}
