using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private GameObject weapon;
    [SerializeField] private float weaponRotationSpeed = 20f;
    private float horizontal, vertical, direction;
    private Animator animator;

    void Start()
    {
        mapGenerator.Initialize(transform.position);
        animator = GetComponent<Animator>();
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
        Vector3 movement = new Vector3(horizontal * direction, vertical, 0).normalized;
        transform.Translate(movement * playerSpeed * Time.deltaTime);

        if (horizontal != 0)
        {
            float angle = horizontal < 0 ? 0 : 180;
            direction = horizontal < 0 ? 1 : -1;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        bool isMoving = movement.magnitude > 0;
        animator.SetBool("IsMoving", isMoving);
        if(isMoving)
        {
            RotateWeapon();
        }
    }

    private void RotateWeapon()
    {
        if (weapon != null)
        {
            float rotationZ = Mathf.PingPong(Time.time * weaponRotationSpeed, 15) - 7.5f;
            weapon.transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }

    private void CheckPlayerPosition()
    {
        mapGenerator.CheckPlayerPosition(transform.position);
    }
}
