using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 99;
    TextMeshProUGUI livesCountText;

    private bool gameLost;
    // Start is called before the first frame update
    void Start()
    {
        livesCountText = GetComponent<TextMeshProUGUI>();
        UpdateLivesDisplay();
        gameLost = false;
    }

    private void UpdateLivesDisplay()
    {
        livesCountText.text = lives.ToString();
    }

    public void AttackerReachedBase(int livesValue = 1)
    {
        if (!gameLost)
        {
            lives -= livesValue;
            UpdateLivesDisplay();

            if (lives <= 0)
            {
                gameLost = true;
                FindObjectOfType<LevelController>().LevelLose();
                lives = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
