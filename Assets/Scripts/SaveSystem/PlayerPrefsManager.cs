using UnityEngine;

[System.Serializable]
public class PlayerPrefsManager : MonoBehaviour
{
    public static int Money
    {
        get { return PlayerPrefs.GetInt(nameof(Money), 0); }
        set { PlayerPrefs.SetInt(nameof(Money), value); }
    }
}
