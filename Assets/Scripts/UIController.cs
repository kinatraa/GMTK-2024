using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI[] ammo;
    [SerializeField] private GameObject[] ammoButton;
    [SerializeField] private GameObject border;

    void Update()
    {
        health.text = "HP: ";
        health.text += PlayerController.health.ToString();
        health.text += " / 100";
        for (int i = 0; i < ammo.Length; i++)
        {
            ammo[i].text = GunController.ammo[i].ToString();
        }
    }

    public void SetBorder(int id)
    {
        Vector3 newPos = ammoButton[id].transform.position;
        newPos.y = border.transform.position.y;
        newPos.z = border.transform.position.z;
        border.transform.position = newPos;
    }
}
