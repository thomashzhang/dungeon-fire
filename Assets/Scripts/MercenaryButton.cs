using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryButton : MonoBehaviour
{
    [SerializeField] Mercenary defenderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        UpdateButtonCost();
    }

    private void UpdateButtonCost()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<MercenaryButton>();
        foreach (var button in buttons)
        {
            if (button == this)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                FindObjectOfType<PlaceMercenary>().SetSelectedDefender(defenderPrefab);
            }
            else
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(63, 63, 63, 255);
            }
        }
    }
}
