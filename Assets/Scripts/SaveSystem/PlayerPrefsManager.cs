using SaveSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPrefsManager : MonoBehaviour
{
    public static int Rubies
    {
        get { return PlayerPrefs.GetInt(nameof(Rubies), 0); }
        set { PlayerPrefs.SetInt(nameof(Rubies), value); }
    }

    public static int Lives
    {
        get { return PlayerPrefs.GetInt(nameof(Lives), 5); }
        set { PlayerPrefs.SetInt(nameof(Lives), value); }
    }

    public static int MaxLevelsUnlocked
    {
        get { return PlayerPrefs.GetInt(nameof(MaxLevelsUnlocked), 1); }
        set { PlayerPrefs.SetInt(nameof(MaxLevelsUnlocked), value); }
    }

    public static void SaveStarsForLevel(int level, int stars)
    {
        // Perform validation
        if (level <= 0 || stars < 0 || stars > 3)
        {
            throw new Exception("invalid data when trying to save stars for level");
        }
        var currentStarList = Stars;
        // Save level to index - 1 position, ex, level 1 = index 0, level 5 = index 4
        while (currentStarList.Count < level)
        {
            currentStarList.Add(0);
        }
        currentStarList[level - 1] = stars;
        Stars = currentStarList;
    }

    public static int GetStarsForLevel(int level)
    {
        // Handle the case we're looking for stars, but haven't completed the level yet, this results in 0 stars
        if (Stars.Count < level)
        {
            return 0;
        }
        return Stars[level - 1];
    }

    private static List<int> Stars
    {
        get { return EasySave.Load(nameof(Stars), new List<int>()); }
        set { EasySave.Save(nameof(Stars), value); }
    }

    #region upgrades
    // WARNING, DO NOT RENAME THESE VARIABLES AS THERE ARE STRING REFERENCES
    public static int LivesUpgradeLevel
    {
        get { return PlayerPrefs.GetInt(nameof(LivesUpgradeLevel), 19); }
        set { PlayerPrefs.SetInt(nameof(LivesUpgradeLevel), value); }
    }

    public static int Walls
    {
        get { return PlayerPrefs.GetInt(nameof(Walls), 0); }
        set { PlayerPrefs.SetInt(nameof(Walls), value); }
    }

    public static int WallsUpgradeLevel
    {
        get { return PlayerPrefs.GetInt(nameof(WallsUpgradeLevel), 19); }
        set { PlayerPrefs.SetInt(nameof(WallsUpgradeLevel), value); }
    }

    public static int Defenders
    {
        get { return PlayerPrefs.GetInt(nameof(Defenders), 0); }
        set { PlayerPrefs.SetInt(nameof(Defenders), value); }
    }

    public static int DefendersUpgradeLevel
    {
        get { return PlayerPrefs.GetInt(nameof(DefendersUpgradeLevel), 40); }
        set { PlayerPrefs.SetInt(nameof(DefendersUpgradeLevel), value); }
    }

    public static int Prep
    {
        get { return PlayerPrefs.GetInt(nameof(Prep), 0); }
        set { PlayerPrefs.SetInt(nameof(Prep), value); }
    }

    public static int PrepUpgradeLevel
    {
        get { return PlayerPrefs.GetInt(nameof(PrepUpgradeLevel), 22); }
        set { PlayerPrefs.SetInt(nameof(PrepUpgradeLevel), value); }
    }
    #endregion
}
