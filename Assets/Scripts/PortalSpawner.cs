using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] portals;
    [SerializeField] private GameObject player;

    public static double portalTimer;

    private List<GameObject> currentPortals = new List<GameObject>();

    void Start()
    {
        portalTimer = -10f;
    }

    void Update()
    {
        if (ButtonManager.onMenu)
        {
            return;
        }
        if(Time.time - portalTimer >= 15f)
        {
            DisablePortals();
            if (!PlayerController.inWaterZone)
            {
                SpawnPortals();
            }
            portalTimer = Time.time;
        }
    }

    private void DisablePortals()
    {
        List<GameObject> portalsToRemove = new List<GameObject>(currentPortals);

        foreach (var port in portalsToRemove)
        {
            Destroy(port);
            currentPortals.Remove(port);
        }
    }

    private void SpawnPortals()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 randomPosition = Random.insideUnitCircle * 20f;
            Vector3 spawnPosition = player.transform.position + randomPosition;

            int rnd = Random.Range(0, portals.Length);
            Debug.Log(rnd);

            GameObject newPort = Instantiate(portals[rnd], transform.position, Quaternion.identity);
            newPort.transform.position = spawnPosition;

            currentPortals.Add(newPort);
        }
    }
}
