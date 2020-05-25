using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDefenders : MonoBehaviour
{
    [SerializeField] GameObject defenderPrefab;
    [SerializeField] float xPosition = 1f;
    [SerializeField] float minYPosition = 0.5f;
    [SerializeField] float maxYPosition = 5f;
    private float yDistanceBetweenDefenders;
    private int numberOfDefenders;
    // Start is called before the first frame update
    void Start()
    {
        numberOfDefenders = 5;
        yDistanceBetweenDefenders = (maxYPosition - minYPosition) / (numberOfDefenders + 1);
        SpawnLinedUpDefenders();
    }

    private void SpawnLinedUpDefenders()
    {
        for (int i = 0; i < numberOfDefenders; i++)
        {
            Vector2 spawnPos = new Vector2(xPosition, minYPosition + ((i + 1) * yDistanceBetweenDefenders));
            var g = Instantiate(defenderPrefab, spawnPos, Quaternion.identity);
            g.name = $"Defender {i + 1}";
            g.transform.parent = gameObject.transform;
            g.GetComponentInChildren<MultilaneShooter>().Body.sortingOrder = g.GetComponentInChildren<MultilaneShooter>().Body.sortingOrder + (numberOfDefenders - i - 1);
        }
    }
}
