using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject star2;
    private GameObject star3;
    private LivesDisplay livesDisplay;

    private void OnEnable()
    {
        var levelController = FindObjectOfType<LevelController>();
        star2 = GameObject.Find("Star 2");
        star3 = GameObject.Find("Star 3");
        livesDisplay = FindObjectOfType<LivesDisplay>();
        if (star2 == null || star3 == null || livesDisplay == null)
        {
            Debug.LogWarning("Star 2, Star 3 or LivesDisplay is null, can't properly display stars at end level");
            return;
        }
        if (livesDisplay.LivesLostRatio() < 0.5)
        {
            star2.GetComponent<Image>().color = new Color32(63, 63, 63, 200);
            star3.GetComponent<Image>().color = new Color32(63, 63, 63, 200);
            PlayerPrefsManager.SaveStarsForLevel(levelController.GetGameLevel(), 1);
        }
        else if (livesDisplay.LivesLostRatio() < 1)
        {
            star2.GetComponent<Image>().color = Color.white;
            star3.GetComponent<Image>().color = new Color32(63, 63, 63, 200);
            PlayerPrefsManager.SaveStarsForLevel(levelController.GetGameLevel(), 2);
        }
        else
        {
            PlayerPrefsManager.SaveStarsForLevel(levelController.GetGameLevel(), 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
