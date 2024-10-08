using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (!onScreen)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.simulated = false;

            MaggotController x = transform.parent.GetComponent<MaggotController>();
            x.DealDamage();

            animator.SetBool("IsSplat", true);
        }
    }

    public void DestroyAcid()
    {
        Destroy(gameObject);
    }
}
