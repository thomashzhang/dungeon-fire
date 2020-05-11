using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, projectilePosition;
    [SerializeField] GameObject createVFX;
    // Start is called before the first frame update
    void Start()
    {
        var createVFXObject = Instantiate(createVFX, transform.position, transform.rotation);
        Destroy(createVFXObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Instantiate(projectile, projectilePosition.transform.position, projectilePosition.transform.rotation);
    }
}
