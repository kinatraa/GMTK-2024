using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float damage = 2f;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;

            if (collision.gameObject.layer == 7){
                BeetleController x = collision.transform.GetComponent<BeetleController>();
                x.TakeDamage(damage, 1);
            }
            if(collision.gameObject.layer == 8){
                MaggotController x = collision.transform.GetComponent<MaggotController>();
                x.TakeDamage(damage, 2);
            }
            if(collision.gameObject.layer == 9){
                BoomController x = collision.transform.GetComponent<BoomController>();
                x.TakeDamage(damage, 3);
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Gordo"))
        {
            GordoBase x = collision.transform.GetComponent<GordoBase>();
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            if (x.name == "GordoFrog")
            {
                if(this.name == "bullet1(Clone)")
                {
                    x.TakeDamage();
                }
            }
            else if (x.name == "GordoFreg")
            {
                if (this.name == "bullet2(Clone)")
                {
                    x.TakeDamage();
                }
            }
            else if (x.name == "GordoFrig")
            {
                if (this.name == "bullet3(Clone)")
                {
                    x.TakeDamage();
                }
            }
            Destroy(gameObject);
        }
    }
}
