using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RubiesEarned : MonoBehaviour
{
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

    public void TriggerLevelWinAddRubies()
    {
        PlayerPrefsManager.Rubies += rubiesObtainedThisLevel;
    }

    public int RubiesObtained()
    { 
        return rubiesObtainedThisLevel;
    }
}
