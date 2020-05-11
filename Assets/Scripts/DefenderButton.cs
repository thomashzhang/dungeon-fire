using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons)
        {
            if (button == this)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                FindObjectOfType<PlaceDefender>().SetSelectedDefender(defenderPrefab);
            }
            else
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(63, 63, 63, 255);
            }
        }
    }
}
