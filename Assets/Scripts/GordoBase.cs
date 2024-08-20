using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordoBase : MonoBehaviour
{
    private int health = 33;
    
    public void TakeDamage()
    {
        health--;
        Vector3 scale = transform.localScale;
        scale.x += 0.1f;
        scale.y += 0.1f;
        transform.localScale = scale;
    }

    private void Die()
    {
        //
    }
}
