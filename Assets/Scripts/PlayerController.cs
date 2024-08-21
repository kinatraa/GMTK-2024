using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameWinLose game;

    public static int maxHealth = 100;
    public static int health;

    public static bool inWaterZone = false;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        game.SetLose();
        ButtonManager.onMenu = true;
        Destroy(gameObject);
    }
}
