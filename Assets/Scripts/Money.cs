using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
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
        moneyText.text = $"${PlayerPrefsManager.Money}";
    }

    public void SubtractMoney(int amount)
    {
        if (amount <= PlayerPrefsManager.Money)
        {
            PlayerPrefsManager.Money -= amount;
        }
        UpdateMoneyDisplay();
    }

    public void AddMoney(int amount)
    {
        PlayerPrefsManager.Money += amount;
        UpdateMoneyDisplay();
    }
}
