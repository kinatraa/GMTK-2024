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
        if (!IsVisibleToCamera())
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleToCamera()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.isVisible;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
            animator.SetBool("IsSplat", true);
        }
    }

    public void DestroyAcid()
    {
        Destroy(gameObject);
    }
}
