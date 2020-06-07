using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RubiesEarned : MonoBehaviour
{
    [SerializeField] float rubiesMultiplier = 1f;
    private int rubiesObtainedThisLevel;
    // Start is called before the first frame update
    void Start()
    {
        rubiesObtainedThisLevel = 0;
    }

    public void AddRubies(int amount)
    {
        rubiesObtainedThisLevel += amount;
    }

    public void TriggerLevelEndAddRubiesToPlayerPrefs()
    {
        PlayerPrefsManager.Rubies += Mathf.RoundToInt(rubiesObtainedThisLevel * rubiesMultiplier);
    }

    public int RubiesObtained()
    { 
        return rubiesObtainedThisLevel;
    }
}
