using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotController : EnemyBase
{
    private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    protected override void Start()
    {
        base.Start();
        health = 10f;
        speed = 3f;
        attackRange = 7f;
        attackCooldown = 2f;
        bulletSpawnPoint = transform.GetChild(0);
    }

    protected override IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        Shoot();

        yield return new WaitForSeconds(animationDuration);

        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        Vector2 direction = (target.position - bulletSpawnPoint.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
