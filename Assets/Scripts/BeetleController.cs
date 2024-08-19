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
    }

    protected override IEnumerator Attack()
    {
        yield return StartCoroutine(base.Attack());

    }
}
