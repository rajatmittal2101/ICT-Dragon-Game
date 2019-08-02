using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_1 : MonoBehaviour
{
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;
    private Vector3 moveDirection = Vector3.zero;

    private float rotation_Speed = 30f;

void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

void Update()
    {
        RotatePlayer();
    }

void FixedUpdate()
    {
        DetectMovement();
    }

void DetectMovement()
    {
        transform.Translate(0f, 0f, Input.GetAxis("Vertical"));
       /* myBody.velocity = new Vector3(
              myBody.velocity.x,//Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (walk_Speed),
              myBody.velocity.y,
              Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (z_Speed));
         */ //MOVEMENT
    }

void RotatePlayer()
    {
            transform.Rotate(0f, Input.GetAxis("Horizontal"), 0f);
       
    }
}

