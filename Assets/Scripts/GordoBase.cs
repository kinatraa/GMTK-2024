using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordoBase : MonoBehaviour
{
    private PolygonCollider2D gordoCollider;
    private int health = 33;

    void Start()
    {
        gordoCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage()
    {
        health--;
        Vector3 scale = transform.localScale;
        scale.x += 0.1f;
        scale.y += 0.1f;
        transform.localScale = scale;
        gordoCollider.enabled = false;
        gordoCollider.enabled = true;
    }

    private void Die()
    {
        ++GameWinLose.cnt;
        Destroy(gameObject);
        //
    }
}
