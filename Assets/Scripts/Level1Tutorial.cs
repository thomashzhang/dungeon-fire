using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Tutorial : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void DoneTutorial()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
