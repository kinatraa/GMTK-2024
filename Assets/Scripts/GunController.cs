using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] private float bulletSpeed = 50f;
    private int bulletID = 0;
    private float cooldownTime = 0.5f;
    private float nextFireTime = 0f;

    private Transform playerTransform;
    private PlayerMovement player;

    public static int[] ammo = new int[4];

    public UIController ui;

    void Start()
    {
        playerTransform = transform.parent;
        player = playerTransform.GetComponent<PlayerMovement>();
        for(int i = 0; i < ammo.Length; i++)
        {
            ammo[i] = 0;
        }
        ammo[0] = 20;
    }

    void Update()
    {
        if (ButtonManager.onMenu)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            bulletID = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            bulletID = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            bulletID = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            bulletID = 3;
        }
        ui.SetBorder(bulletID);
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            if (ammo[bulletID] > 0)
            {
                --ammo[bulletID];
                Shoot();
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefabs[bulletID], bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    public void AddBullet(int id)
    {
        ammo[id]++;
    }
}

