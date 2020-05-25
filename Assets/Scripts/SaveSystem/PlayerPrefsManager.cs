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
}
