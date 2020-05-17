using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")] [SerializeField] float levelTime = 60;
    bool triggeredLevelFinished;
    private Slider slider;
    private LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        triggeredLevelFinished = false;
        slider = FindObjectOfType<Slider>();
        levelController = FindObjectOfType<LevelController>();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        slider.direction = Slider.Direction.LeftToRight;
        slider.value = 0;
        while (!levelController.GetGameStartInitiated())
        {
            yield return new WaitForSeconds(0.05f);
            slider.value = Time.timeSinceLevelLoad <= levelController.GetGameStartDelaySeconds() ? Time.timeSinceLevelLoad / levelController.GetGameStartDelaySeconds() : 1;
        }
        slider.direction = Slider.Direction.RightToLeft;
        slider.value = 0;
        while (!triggeredLevelFinished)
        {
            yield return new WaitForSeconds(0.05f);
            slider.value = Time.timeSinceLevelLoad - levelController.GetGameStartDelaySeconds() <= levelTime ? (Time.timeSinceLevelLoad - levelController.GetGameStartDelaySeconds()) / levelTime : 1;
            // TODO: Move out of update
            if (TimerOver())
            {
                triggeredLevelFinished = true;
                levelController.LevelTimerFinished();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool TimerOver()
    {
        return Time.timeSinceLevelLoad - levelController.GetGameStartDelaySeconds() >= levelTime;
    }
}
