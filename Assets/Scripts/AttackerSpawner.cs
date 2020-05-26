using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 2f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] float initialDelay = 0f;
    [SerializeField] Attacker[] attackerSpawnList;

    bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAttackers());
    }

    private IEnumerator SpawnAttackers()
    {
        if (initialDelay > 0)
        {
            int levelDelay = FindObjectOfType<LevelController>().GetGameStartDelaySeconds();
            yield return new WaitForSeconds(levelDelay + initialDelay);
        }
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawn)
            {
                SpawnAttacker();
            }
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

    public void SetSpawn(bool spawn)
    {
        this.spawn = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
