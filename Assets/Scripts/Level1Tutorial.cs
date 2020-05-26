using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
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
