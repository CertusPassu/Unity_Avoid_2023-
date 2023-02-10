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
    private float animationDuration = 3.0f;
    private bool isDead;
    private float startTime;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    void Update()
    {
        if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * _speed * Time.deltaTime);
            return;
        }
        Move();
    }

    private void Move()
    {
        if (isDead)
            return;
        if (controller.isGrounded)
        {
            verticalVelocity = 0f;
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

    public void SetSpeed(float modifier)
    {
        _speed = 0.3f * modifier;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
            Die();
    }
    private void Die()
    {
        isDead = true;
        GetComponent<ScoreManager>().OnDie();
    }
}
