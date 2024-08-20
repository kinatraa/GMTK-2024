using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        health = 4f;
        speed = 8f;
        attackRange = 3f;
        attackCooldown = 1f;
        damage = 10;
    }

    protected override void MoveTowardsTarget()
    {
        if (isAttacking)
        {
            return;
        }

        float dist = Vector3.Distance(target.position, transform.position);

        if (dist > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        Vector3 direction = target.position - transform.position;
        if (direction.x < 0 && transform.localScale.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (direction.x > 0 && transform.localScale.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    protected override IEnumerator Attack()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        yield return new WaitForSeconds(animationDuration);

        animator.SetBool("IsBoom", true);
    }

    public override void DealDamage()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= 2f)
        {
            base.DealDamage();
        }
        base.Die();
    }
}
