using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _speed = 0.1f;
    float _turnSpeed = 3f;
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        controller.Move(moveVector * Time.deltaTime * _turnSpeed);
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = _speed;
    }
}
