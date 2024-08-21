using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private Transform gun;
    private float horizontal, vertical;
    private Animator animator;
    private int dir = 1;

    void Start()
    {
        /*mapGenerator.Initialize(transform.position);*/
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /*CheckPlayerPosition();*/
        if (!ButtonManager.onMenu)
        {
            Movement();
        }
        RotatePlayerTowardsMouse();
    }

    private void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal * dir, vertical, 0).normalized;
        transform.Translate(movement * playerSpeed * Time.deltaTime);

        bool isMoving = movement.magnitude > 0;
        animator.SetBool("IsMoving", isMoving);
    }

    private void RotatePlayerTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        Vector3 gunDir = mousePosition - gun.position;
        float gunAngle = Mathf.Atan2(gunDir.y, gunDir.x) * Mathf.Rad2Deg;

        if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gun.rotation = Quaternion.Euler(180, 180, gunAngle);
            dir = 1;
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gun.rotation = Quaternion.Euler(0, 180, -gunAngle);
            dir = -1;
        }
    }

    public int GetDirectionFacing()
    {
        return dir;
    }
}
