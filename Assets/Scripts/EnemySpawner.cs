using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private KeyValuePair<float, float> spawnTimer = new KeyValuePair<float, float>(2, 5);
    private float spawnTime;

    private void Awake()
    {
        SetTimeSpawn();
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Instantiate(enemies[0], transform.position, Quaternion.identity);
            SetTimeSpawn();
        }
    }

    private void SetTimeSpawn()
    {
        spawnTime = Random.Range(spawnTimer.Value, spawnTimer.Key);
    }
}
