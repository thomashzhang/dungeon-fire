using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceWallHealth : WallHealth
{
    // Start is called before the first frame update
    protected override void Start()
    {
        var walls = PlayerPrefsManager.Walls;
        if (walls <= 0)
        {
            // Enable or disabled walls based on whether the user bought them
            gameObject.SetActive(false);
        }
        else
        {
            startingHealth = walls;
        }
        base.Start();
    }
}
