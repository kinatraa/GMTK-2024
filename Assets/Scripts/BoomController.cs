using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        health = 10f;
        speed = 3f;
        attackRange = 3f;
        attackCooldown = 1f;
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


}
