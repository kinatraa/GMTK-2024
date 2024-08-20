using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;

    void Update()
    {
        health.text = PlayerController.health.ToString();
    }
}
