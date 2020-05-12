using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 2f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerSpawnList;

    bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAttackers());
    }

    private IEnumerator SpawnAttackers()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        if (attackerSpawnList != null && attackerSpawnList.Length > 0)
        {
            var attacker = Instantiate(attackerSpawnList[Random.Range(0, attackerSpawnList.Length)], transform.position, transform.rotation);
            attacker.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
