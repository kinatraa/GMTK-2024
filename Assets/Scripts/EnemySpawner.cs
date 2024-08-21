using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private KeyValuePair<float, float> spawnTimer = new KeyValuePair<float, float>(2, 5);
    private float spawnTime;
    private float waitTime;

    private void Awake()
    {
        waitTime = Time.time;
        SetTimeSpawn();
    }

    void Update()
    {
        if(Time.time - waitTime >= 3f)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0 && !PlayerController.inWaterZone)
            {
                if (transform.childCount < 5)
                {
                    Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                }
                SetTimeSpawn();
            }
        }
    }

    private void SetTimeSpawn()
    {
        spawnTime = Random.Range(spawnTimer.Value, spawnTimer.Key);
    }
}
