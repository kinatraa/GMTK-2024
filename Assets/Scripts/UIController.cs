using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI[] ammo;

    void Update()
    {
        health.text = PlayerController.health.ToString();
        for (int i = 0; i < ammo.Length; i++)
        {
            ammo[i].text = GunController.ammo[i].ToString();
        }
    }
}
