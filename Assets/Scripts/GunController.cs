using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 50f;
    private float cooldownTime = 0.5f;
    private float nextFireTime = 0f;

    private Transform playerTransform;
    private PlayerMovement player;

    public static int maxAmmo = 20;
    public static int ammo;

    void Start()
    {
        playerTransform = transform.parent;
        player = playerTransform.GetComponent<PlayerMovement>();
        ammo = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            if (ammo > 0)
            {
                --ammo;
                Shoot();
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }
}

