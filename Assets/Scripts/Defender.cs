using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int crystalCost = 10;
    [SerializeField] GameObject createVFX;
    // Start is called before the first frame update
    void Start()
    {
        if (createVFX != null)
        {
            var createVFXObject = Instantiate(createVFX, transform.position, transform.rotation);
            Destroy(createVFXObject, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CreateDefenderCrystalCost()
    {
        return FindObjectOfType<CrystalDisplay>().SpendCrystals(crystalCost);
    }
}
