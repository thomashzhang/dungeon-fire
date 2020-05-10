using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, projectilePosition;
    // Start is called before the first frame update
    void Start()
    {

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
