using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
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
            if (transform.childCount < 5)
            {
                GameObject newE = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                newE.transform.SetParent(transform, true);
            }
            SetTimeSpawn();
        }
    }

    private void SetTimeSpawn()
    {
        spawnTime = Random.Range(spawnTimer.Value, spawnTimer.Key);
    }
}
