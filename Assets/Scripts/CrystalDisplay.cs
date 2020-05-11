using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrystalDisplay : MonoBehaviour
{
    [SerializeField] int crystals = 100;
    TextMeshProUGUI crystalsCountText;
    // Start is called before the first frame update
    void Start()
    {
        crystalsCountText = GetComponent<TextMeshProUGUI>();
        UpdateCrystalsDisplay();
    }

    private void UpdateCrystalsDisplay()
    {
        crystalsCountText.text = crystals.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns>true if the spend was successful, false otherwise</returns>
    public bool SpendCrystals(int count)
    {
        if (crystals >= count)
        {
            crystals -= count;
            UpdateCrystalsDisplay();
            return true;
        }
        return false;
    }

    public void AddCrystals(int count)
    {
        crystals += count;
        UpdateCrystalsDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
