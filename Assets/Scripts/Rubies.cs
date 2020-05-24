using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rubies : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        UpdateRubyDisplay();
    }

    private void UpdateRubyDisplay()
    {
        moneyText.text = PlayerPrefsManager.Rubies.ToString();
    }

    public void SubtractRubies(int amount)
    {
        if (amount <= PlayerPrefsManager.Rubies)
        {
            PlayerPrefsManager.Rubies -= amount;
        }
        UpdateRubyDisplay();
    }

    public void AddRubies(int amount)
    {
        PlayerPrefsManager.Rubies += amount;
        UpdateRubyDisplay();
    }
}
