using UnityEngine;

[System.Serializable]
public class PlayerPrefsManager : MonoBehaviour
{
    // WARNING, DO NOT RENAME THESE VARIABLES AS THERE ARE STRING REFERENCES
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
        get { return PlayerPrefs.GetInt(nameof(DefendersUpgradeLevel), 50); }
        set { PlayerPrefs.SetInt(nameof(DefendersUpgradeLevel), value); }
    }
}
