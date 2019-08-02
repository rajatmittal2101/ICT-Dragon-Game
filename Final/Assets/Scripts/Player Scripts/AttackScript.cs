using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;

    void Update()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        //it means if player attack touches enemy than it will put enemy inside array collider[]
        //create a new layer Enemy and in the layer mask select enemy
        //it is for detection of player enemy
        //attack point has a connection with weapon handler script see that
        // drag the attack point and attach it to public variable of weapon handler named Attack_Point

        if (hits.Length > 0)
        { 

            hits[0].gameObject.GetComponent<HealthScript>().ApplyDamage(damage);

            gameObject.SetActive(false);
        }

    }
}


//this script is for player
//create empty object name Attack Point as a child of that part that is used as a weapon
//for dragon his mouth or wings
//attach this script to attack point