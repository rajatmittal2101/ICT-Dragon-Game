using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniverse2 : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float f_radius = 5f;
    public float f_damage = 50f;

    public bool is_Player, is_Enemy;

    public GameObject hit_fx_prefab;


   
    void Update()
    {
        DetectFCollision();
    }

    void DetectFCollision()
    {

        Collider[] hit1 = Physics.OverlapSphere(transform.position, f_radius, collisionLayer);

        if (hit1.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFX_Pos = hit1[0].transform.position;
                Instantiate(hit_fx_prefab, hitFX_Pos, Quaternion.identity);


                if (gameObject.CompareTag("Fire"))
                {
                    hit1[0].GetComponent<HealthScript>().ApplyDamage(f_damage);
                }
                else
                {
                    hit1[0].GetComponent<HealthScript>().ApplyDamage(f_damage);
                }


            }
            gameObject.SetActive(false);
        }
    }
}
