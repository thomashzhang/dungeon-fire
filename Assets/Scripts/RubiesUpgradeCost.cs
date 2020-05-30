using Lean.Gui;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RubiesUpgradeCost : MonoBehaviour
{
    [SerializeField] string upgradeProperty;
    [SerializeField] int statIncreaseAmount = 1;
    [SerializeField] int statIncreaseCap = int.MaxValue;
    private TextMeshProUGUI priceText;
    private TextMeshProUGUI currentStatsText;
    private TextMeshProUGUI nextStatsText;
    private TextMeshProUGUI upgradeButtonText;
    private LeanButton upgradeButton;
    private Rubies rubiesDisplay;
    private const string appendLevelText = "UpgradeLevel";
    void Start()
    {
        priceText = transform.Find("Item Cost").GetComponent<TextMeshProUGUI>();
        currentStatsText = transform.Find("Current Stats").GetComponent<TextMeshProUGUI>();
        nextStatsText = transform.Find("Next Stats").GetComponent<TextMeshProUGUI>();
        upgradeButton = transform.Find("Upgrade Button (LeanButton)").GetComponent<LeanButton>();
        upgradeButtonText = transform.Find("Upgrade Button (LeanButton)/Cap/Text").GetComponent<TextMeshProUGUI>();
        rubiesDisplay = FindObjectOfType<Rubies>();

        UpdateTexts();
    }

    private void UpdateTexts()
    {
        var itemLevel = StringToIntVariable(upgradeProperty);
        SetPriceText(itemLevel, CalculateNextLevelCost());
        SetCurrentStatsText(itemLevel);
        SetNextStatsText(itemLevel + statIncreaseAmount);
        UpdateButtonText(itemLevel);
    }

    private void UpdateButtonText(int itemLevel)
    {
        if (itemLevel <= 0)
        {
            // Make the button a buy button
            upgradeButtonText.text = "Buy";
        }
        else if (itemLevel >= statIncreaseCap)
        {
            upgradeButtonText.text = "Max";
            // TODO: There's a bug where the color doesn't change immediately, but only after reloading the scene
            upgradeButton.transform.Find("Cap").GetComponent<Image>().color = new Color32(63, 63, 63, 200);
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeButtonText.text = "Upgrade";
        }
    }

    private void SetNextStatsText(int nextLevel)
    {
        if (nextLevel > statIncreaseCap)
        {
            nextStatsText.text = $"Max";
        }
        else
        {
            nextStatsText.text = $"Next: {nextLevel}";
        }
    }

    private void SetCurrentStatsText(int currentLevel)
    {
        currentStatsText.text = $"Cur: {currentLevel}";
    }

    private void SetPriceText(int currentLevel, int price)
    {
        if (currentLevel >= statIncreaseCap)
        {
            priceText.text = "Price: Max";
        }
        else
        {
            priceText.text = $"Price: {price}";
        }
    }

    public int CalculateNextLevelCost()
    {
        var rubiesCostLevel = StringToIntVariable(UpgradePropertyLevelString());
        return (rubiesCostLevel * (rubiesCostLevel + 1)) / 2;
    }

    public void UpgradeItemLevel()
    {
        var currentLevel = StringToIntVariable(upgradeProperty);
        if ((currentLevel + statIncreaseAmount) <= statIncreaseCap  && rubiesDisplay.SubtractRubies(CalculateNextLevelCost()))
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
        else if (stringPlayerPref == nameof(PlayerPrefsManager.Walls))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.Walls += upgradeAmount;
            }
            return PlayerPrefsManager.Walls;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.WallsUpgradeLevel))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.WallsUpgradeLevel += upgradeAmount;
            }
            return PlayerPrefsManager.WallsUpgradeLevel;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.Defenders))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.Defenders += upgradeAmount;
            }
            return PlayerPrefsManager.Defenders;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.DefendersUpgradeLevel))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.DefendersUpgradeLevel += upgradeAmount;
            }
            return PlayerPrefsManager.DefendersUpgradeLevel;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.Prep))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.Prep += upgradeAmount;
            }
            return PlayerPrefsManager.Prep;
        }
        else if (stringPlayerPref == nameof(PlayerPrefsManager.PrepUpgradeLevel))
        {
            if (upgradeAmount > 0)
            {
                PlayerPrefsManager.PrepUpgradeLevel += upgradeAmount;
            }
            return PlayerPrefsManager.PrepUpgradeLevel;
        }
        Debug.LogError("No variable name match for upgrade");
        throw new Exception("No variable name match for upgrade");
    }
}
