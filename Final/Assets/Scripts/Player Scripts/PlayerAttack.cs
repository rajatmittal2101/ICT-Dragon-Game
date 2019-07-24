using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            anim.SetTrigger("Claw");
            
        }

        if (Input.GetKey(KeyCode.V))
        {
            anim.SetTrigger("Fire");

        }
    }
}
