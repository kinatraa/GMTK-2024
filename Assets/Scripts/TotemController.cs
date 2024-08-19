using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float waterRange = 9.2f;

    void Update()
    {
        if (IsInWaterZone())
        {
            Heal();
        }
    }

    private void Heal()
    {

    }

    private bool IsInWaterZone()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        return dist <= waterRange;
    }
}
