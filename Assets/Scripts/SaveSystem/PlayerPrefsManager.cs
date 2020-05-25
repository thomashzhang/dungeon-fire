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
}
