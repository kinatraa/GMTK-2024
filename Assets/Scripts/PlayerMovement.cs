using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private float playerSpeed = 10f;
    private float horizontal, vertical;

    void Start()
    {
        mapGenerator.Initialize(transform.position);
    }

    void Update()
    {
        CheckPlayerPosition();
        Movement();
    }

    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0).normalized;
        gameObject.transform.Translate(movement * playerSpeed * Time.deltaTime);
    }

    private void CheckPlayerPosition()
    {
        mapGenerator.CheckPlayerPosition(transform.position);
    }
}
