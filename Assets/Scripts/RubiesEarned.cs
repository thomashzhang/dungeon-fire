using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RubiesEarned : MonoBehaviour
{
    private int rubiesObtainedThisLevel;
    private bool triggeredLevelEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        rubiesObtainedThisLevel = 0;
    }

    public void AddRubies(int amount)
    {
        if (triggeredLevelEnd)
        {
            return;
        }
        rubiesObtainedThisLevel += amount;
    }

    public void TriggerLevelEndAddRubiesToPlayerPrefs()
    {
        triggeredLevelEnd = true;
        PlayerPrefsManager.Rubies += rubiesObtainedThisLevel;
    }

    public int RubiesObtained()
    { 
        return rubiesObtainedThisLevel;
    }
}
