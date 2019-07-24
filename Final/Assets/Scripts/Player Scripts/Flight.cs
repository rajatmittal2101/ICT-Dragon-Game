using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Flight : MonoBehaviour
{

    public GameObject GroundC;
    public GameObject FlyC;
    private float f_speed = 0.2f;
    private float rSpeed = 1.5f;

    Rigidbody rb;
    Animator anim;
    CapsuleCollider col_size;

    // Use this for initialization 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col_size = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {


        var z = CrossPlatformInputManager.GetAxis("Vertical") * f_speed;
        var y = CrossPlatformInputManager.GetAxis("Horizontal") * rSpeed;


        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        if (CrossPlatformInputManager.GetButton("Up"))
        {
            transform.Translate(0, 0.1f, 0);
        }

        if (CrossPlatformInputManager.GetButton("Down"))
        {
            transform.Translate(0, -0.1f, 0);
        }

        if (GetComponent<PlayerMovement>().isGrounded == false)
        {
            //Running Controls
            if (z > 0)
            {
                anim.SetBool("Fmove", true);
            }
            else
            {
                anim.SetBool("Fmove", false);
            }





        }
        else
        {
            anim.SetTrigger("Land");

            anim.SetBool("Flying", false);
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<Flight>().enabled = false;
            FlyC.SetActive(false);
            GroundC.SetActive(true);

        }

    }






}
