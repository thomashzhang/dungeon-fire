using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    protected virtual void OnMouseDown()
    {
        var buttons = FindObjectsOfType<SelectButton>();
        foreach (var button in buttons)
        {
            if (button == this)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(63, 63, 63, 255);
            }
        }
        FindObjectOfType<LevelController>().DeleteMercenaryModeEnabled = false;
    }
}
