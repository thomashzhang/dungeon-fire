using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] LeanButton[] levelButtons;
    // Start is called before the first frame update
    void Start()
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
