using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleController : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        health = 10f;
        speed = 3f;
        attackRange = 3f;
        attackCooldown = 1f;
        damage = 7;
    }

    protected override IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        yield return new WaitForSeconds(animationDuration);

        DealDamage();

        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
    }

    public override void DealDamage()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= 3.8f)
        {
            base.DealDamage();
        }
    }
}
