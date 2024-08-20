using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform waterZone;
    private float waterRange = 5f;
    private double ammoTimer, healthTimer;

    void Start()
    {
        waterZone = transform.GetChild(0);
        ammoTimer = healthTimer = Time.time;
    }

    void Update()
    {
        if (IsInWaterZone())
        {
            if (Time.time - healthTimer >= 2)
            {
                Heal();
                healthTimer = Time.time;
            }
            if (Time.time - ammoTimer >= 1)
            {
                FillAmmo();
                ammoTimer = Time.time;
            }
        }
    }

    private void Heal()
    {
        if (PlayerController.health < PlayerController.maxHealth)
        {
            PlayerController.health += 10;
            PlayerController.health = Math.Min(PlayerController.health, PlayerController.maxHealth);
        }
    }

    private void FillAmmo()
    {
        if(GunController.ammo[0] < GunController.maxAmmo){
            GunController.ammo[0]++;
            GunController.ammo[0] = Math.Min(GunController.ammo[0], GunController.maxAmmo);
        }
    }

    private bool IsInWaterZone()
    {
        float dist = Vector3.Distance(player.transform.position, waterZone.transform.position);
        return dist <= waterRange;
    }
}
