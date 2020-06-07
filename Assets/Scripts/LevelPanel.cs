using Lean.Gui;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] LeanButton[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        LockLevelsThatHaventBeenCompleted();
        UpdateStarCounts();

    }

    private void UpdateStarCounts()
    {
        var maxLevelReached = PlayerPrefsManager.MaxLevelsUnlocked;
        for (int i = 0; i < maxLevelReached; i++)
        {
            var star1 = levelButtons[i].transform.Find("Cap/Stars Level Display/Star 1");
            var star2 = levelButtons[i].transform.Find("Cap/Stars Level Display/Star 2");
            var star3 = levelButtons[i].transform.Find("Cap/Stars Level Display/Star 3");
            var starsLevelDisplay = levelButtons[i].transform.Find("Cap/Stars Level Display");
            var levelText = levelButtons[i].transform.Find("Cap/Text").gameObject;
            MoveLevelTextToMakeRoomForStars(levelText);
            starsLevelDisplay.gameObject.SetActive(true);
            UpdateStarColorBasedOnStarsCompleted(star1.gameObject, star2.gameObject, star3.gameObject, i + 1);
        }
    }

    private void MoveLevelTextToMakeRoomForStars(GameObject levelText)
    {
        levelText.transform.position = new Vector3(levelText.transform.position.x, 160, levelText.transform.position.z);
    }

    private void UpdateStarColorBasedOnStarsCompleted(GameObject star1, GameObject star2, GameObject star3, int level)
    {
        var stars = PlayerPrefsManager.GetStarsForLevel(level);
        if (stars <= 2)
        {
            star3.GetComponent<Image>().color = new Color32(63, 63, 63, 200);
        }
        if (stars <= 1)
        {
            star2.GetComponent<Image>().color = new Color32(63, 63, 63, 200);
        }
        if (stars <= 0)
        {
            star1.GetComponent<Image>().color = new Color32(63, 63, 63, 200);
        }
    }

    private void LockLevelsThatHaventBeenCompleted()
    {
        var maxLevelReached = PlayerPrefsManager.MaxLevelsUnlocked;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if ((i + 1) > maxLevelReached)
            {
                levelButtons[i].interactable = false;
                levelButtons[i].transform.Find("Cap").GetComponent<Image>().color = new Color32(63, 63, 63, 200);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
