using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrystalDisplay : MonoBehaviour
{
    [SerializeField] int crystals = 100;
    TextMeshProUGUI crystalsCountText;

    private Object crystalsLock;
    // Start is called before the first frame update
    void Start()
    {
        crystalsCountText = GetComponent<TextMeshProUGUI>();
        UpdateCrystalsDisplay();
        crystalsLock = new Object();
    }

    private void UpdateCrystalsDisplay()
    {
        crystalsCountText.text = crystals.ToString();
    }

    /// <summary>
    /// Return true when crystals can be and is spent
    /// Returns false when crystals can't be spent and isn't taken away
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool SpendCrystals(int count)
    {
        lock (crystalsLock)
        {
            if (crystals >= count)
            {
                crystals -= count;
                UpdateCrystalsDisplay();
                return true;
            }
            return false;
        }
    }

    public void AddCrystals(int count)
    {
        lock (crystalsLock)
        {
            crystals += count;
            UpdateCrystalsDisplay();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
