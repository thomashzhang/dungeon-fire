using UnityEngine;

[System.Serializable]
public class PlayerPrefsManager : MonoBehaviour
{
    public static int Rubies
    {
        get { return PlayerPrefs.GetInt(nameof(Rubies), 0); }
        set { PlayerPrefs.SetInt(nameof(Rubies), value); }
    }
}
