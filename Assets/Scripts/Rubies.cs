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
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        moneyText.text = PlayerPrefsManager.Rubies.ToString();
    }

    public void SubtractMoney(int amount)
    {
        if (amount <= PlayerPrefsManager.Rubies)
        {
            PlayerPrefsManager.Rubies -= amount;
        }
        UpdateMoneyDisplay();
    }

    public void AddMoney(int amount)
    {
        PlayerPrefsManager.Rubies += amount;
        UpdateMoneyDisplay();
    }
}
