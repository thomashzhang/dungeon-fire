using System;
using TMPro;
using UnityEngine;

public class RubiesUpgradeCost : MonoBehaviour
{
    [SerializeField] string upgradeProperty;
    [SerializeField] int statIncreaseAmount = 1;
    private TextMeshProUGUI priceText;
    private TextMeshProUGUI currentStatsText;
    private TextMeshProUGUI nextStatsText;
    private Rubies rubiesDisplay;
    private const string appendLevelText = "UpgradeLevel";
    void Start()
    {
        priceText = transform.Find("Item Cost").GetComponent<TextMeshProUGUI>();
        currentStatsText = transform.Find("Current Stats").GetComponent<TextMeshProUGUI>();
        nextStatsText = transform.Find("Next Stats").GetComponent<TextMeshProUGUI>();
        rubiesDisplay = FindObjectOfType<Rubies>();

        UpdateTexts();
    }

    private void UpdateTexts()
    {
        var itemValue = StringToIntVariable(upgradeProperty);
        SetPriceText(CalculateNextLevelCost());
        SetCurrentStatsText(itemValue);
        SetNextStatsText(itemValue + statIncreaseAmount);
    }

    private void SetNextStatsText(int nextLevel)
    {
        nextStatsText.text = $"Next: {nextLevel}";
    }

    private void SetCurrentStatsText(int currentLevel)
    {
        currentStatsText.text = $"Cur: {currentLevel}";
    }

    private void SetPriceText(int price)
    {
        priceText.text = $"Price: {price}";
    }

    public int CalculateNextLevelCost()
    {
        var rubiesCostLevel = StringToIntVariable(UpgradePropertyLevelString());
        return (rubiesCostLevel * (rubiesCostLevel + 1)) / 2;
    }

    public void UpgradeItemLevel()
    {
        if (rubiesDisplay.SubtractRubies(CalculateNextLevelCost()))
        {
            StringToIntVariable(upgradeProperty, statIncreaseAmount);
            StringToIntVariable(UpgradePropertyLevelString(), 1);
            UpdateTexts();
        }
    }

    private string UpgradePropertyLevelString()
    {
        return $"{upgradeProperty}{appendLevelText}";
    }

    public int StringToIntVariable(string stringPlayerPref, int upgradeAmount = 0)
    {
        // TODO: See if there's a better solution without reflection preferably
        if (stringPlayerPref == nameof(PlayerPrefsManager.Rubies))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.Rubies += upgradeAmount;
            }
            return PlayerPrefsManager.Rubies;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.Lives))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.Lives += upgradeAmount;
            }
            return PlayerPrefsManager.Lives;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.LivesUpgradeLevel))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.LivesUpgradeLevel += upgradeAmount;
            }
            return PlayerPrefsManager.LivesUpgradeLevel;
        }
        Debug.LogError("No variable name match for upgrade");
        throw new Exception("No variable name match for upgrade");
    }
}
