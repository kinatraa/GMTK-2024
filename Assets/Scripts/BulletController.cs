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
        if (!collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.gameObject.layer == 7){
                BeetleController x = collision.transform.GetComponent<BeetleController>();
                x.TakeDamage(damage);
            }
            if(collision.gameObject.layer == 8){
                MaggotController x = collision.transform.GetComponent<MaggotController>();
                x.TakeDamage(damage);
            }
            if(collision.gameObject.layer == 9){
                BoomController x = collision.transform.GetComponent<BoomController>();
                x.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
