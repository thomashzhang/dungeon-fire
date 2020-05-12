using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 99;
    TextMeshProUGUI livesCountText;
    // Start is called before the first frame update
    void Start()
    {
        livesCountText = GetComponent<TextMeshProUGUI>();
        UpdateLivesDisplay();
    }

    private void UpdateLivesDisplay()
    {
        livesCountText.text = lives.ToString();
    }

    public void AttackerReachedBase(int livesValue = 1)
    {
        lives -= livesValue;
        UpdateLivesDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelLoad>().LoadLoseScreen();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
