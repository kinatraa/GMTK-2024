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
        health = 6f;
        speed = 3f;
        attackRange = 7f;
        attackCooldown = 2f;
        damage = 5;
        bulletSpawnPoint = transform.GetChild(0);
    }

    protected override IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        Shoot();

        rb.simulated = true;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;
        yield return new WaitForSeconds(animationDuration);

        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
    }

    public override void DealDamage()
    {
        base.DealDamage();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.transform.SetParent(transform);

        Vector2 direction = (target.position - bulletSpawnPoint.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
