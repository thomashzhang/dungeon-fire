using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Mercenary
{
    [SerializeField] int generateAmount = 10;
    public void GenerateCrystals(int amount)
    {
        FindObjectOfType<CrystalDisplay>().AddCrystals(generateAmount);
    }
}
