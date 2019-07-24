using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public bool isGrounded;


    private float speed;

    public float w_speed = 0.03f;
    public float r_speed = 0.08f;
    public float rotSpeed = 1;

    Rigidbody rb;
    Animator anim;
    CapsuleCollider col_size;
    public ParticleSystem fireEffect;
    //public ParticleSystem smokeEffect;

    // Use this for initialization 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col_size = GetComponent<CapsuleCollider>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {


        var z = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        var y = CrossPlatformInputManager.GetAxis("Horizontal") * rotSpeed;


        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        //transform.Translate(0, -0.1f, 0);




        speed = r_speed;
        //Running Controls
        if (z > 0)
        {
            speed = r_speed;
            anim.SetBool("Run", true);
            anim.SetBool("Movement", false);
        }
        else if (z<0)
        {
            speed = w_speed;
            anim.SetBool("Run", false);
            anim.SetBool("Movement", true);
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Movement", false);
        }



        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            anim.SetTrigger("Fly");
            transform.Translate(0, 1f, 0);
            anim.SetBool("Flying", true);
            gameObject.GetComponent<Flight>().enabled = true;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
        }

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            anim.SetTrigger("Claw");

        }

        if (CrossPlatformInputManager.GetButton("Fire2"))
        {
            anim.SetTrigger("Fire");
            fireEffect.Play();
            //smokeEffect.Play();



        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
