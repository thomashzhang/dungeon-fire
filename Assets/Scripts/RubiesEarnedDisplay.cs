using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RubiesEarnedDisplay : MonoBehaviour
{
    private TextMeshProUGUI rubiesText;
    // Start is called before the first frame update
    void Start()
    {
        rubiesText = GetComponent<TextMeshProUGUI>();
        UpdateRubyDisplay();
    }

    private void UpdateRubyDisplay()
    {
        var rubiesEarned = FindObjectOfType<RubiesEarned>();
        if (rubiesEarned != null)
        {
            rubiesText.text = $"+{rubiesEarned.RubiesObtained()}";
        }
        else
        {
            Debug.LogWarning("Can't find rubies earned object, did you add it to the core game logic game object?");
        }
    }
}
