using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100;
    public static float health;

    void Start()
    {
        health = maxHealth;
    }
}
