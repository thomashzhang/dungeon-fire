using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")] [SerializeField] float levelTime = 60;
    bool triggeredLevelFinished;
    // Start is called before the first frame update
    void Start()
    {
        triggeredLevelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        FindObjectOfType<Slider>().value = Time.timeSinceLevelLoad <= levelTime ? Time.timeSinceLevelLoad / levelTime : 1;
        // TODO: Move out of update
        if (TimerOver())
        {
            triggeredLevelFinished = true;
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }

    public bool TimerOver()
    {
        return Time.timeSinceLevelLoad >= levelTime;
    }
}
