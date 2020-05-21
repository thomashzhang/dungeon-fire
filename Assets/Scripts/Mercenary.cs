using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercenary : MonoBehaviour
{
    [SerializeField] int crystalCost = 10;
    [SerializeField] GameObject createVFX;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (createVFX != null)
        {
            var createVFXObject = Instantiate(createVFX, transform.position, transform.rotation);
            Destroy(createVFXObject, 1f);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public bool CreateDefenderCrystalCost()
    {
        return FindObjectOfType<CrystalDisplay>().SpendCrystals(crystalCost);
    }

    public int GetCrystalCost()
    {
        return crystalCost;
    }
}
