using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;

    private EnemyState enemy_State;

    public float walk_Speed = 0.5f;             //speed of idle Dragon
    public float run_Speed = 4f;                //speed of running dragon

    public float chase_Distance = 20f;          //Circle of Dragon
    private float current_Chase_Distance;       //automatic chase if enemy hits by player
    public float attack_Distance = 1.8f;
    public float chase_After_Attack_Distance = 2f;  //allowed space by enemy for chase the player again 

    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_For_This_Time = 15f;
    private float patrol_Timer;

    public float wait_Before_Attack = 2f;
    private float attack_Timer;

    private Transform target;               //player

    public GameObject attack_Point;


    void Awake()
    {
        enemy_Anim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy_State = EnemyState.PATROL;

        patrol_Timer = patrol_For_This_Time;

        //when the enemy first gets to the player
        //attack right away
        attack_Timer = wait_Before_Attack;

        //memorize the value of chase distance
        //so that we can put it back
        current_Chase_Distance = chase_Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_State==EnemyState.PATROL)
        {
            Patrol();
        }

        if (enemy_State == EnemyState.CHASE)
        {
            Chase();
        }

        if (enemy_State == EnemyState.ATTACK)
        {
            Attack();
        }

    }

    void Patrol()
    {

        //tell nav agent that he can move
        navAgent.isStopped = false;
        navAgent.speed = walk_Speed;

        patrol_Timer += Time.deltaTime;

        if(patrol_Timer>patrol_For_This_Time)
        {
            SetNewRandomDestination();
            patrol_Timer = 0f;
        }

        if(navAgent.velocity.sqrMagnitude > 0)
        {
            enemy_Anim.Walk(true);
        }
        else
        {
            enemy_Anim.Walk(false);
        }

        //test the distance between player and enemy
        if(Vector3.Distance(transform.position,target.position)<=chase_Distance)
        {

            enemy_Anim.Walk(false);

            enemy_State = EnemyState.CHASE;

            //PLAY SPOTTED AUDIO

        }

    }//patrol

    void Chase()
    {

        //enavle the agent to move again
        navAgent.isStopped = false;
        navAgent.speed = run_Speed;

        //set the player's position as the destination
        //because we are chasing running towards the player
        navAgent.SetDestination(target.position);

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemy_Anim.Run(true);
        }
        else
        {
            enemy_Anim.Run(false);
        }

        //if the siatance between enemy and player is less than attack distance
        if (Vector3.Distance(transform.position,target.position)<=attack_Distance)
        {

            //stop the animations
            enemy_Anim.Run(false);
            enemy_Anim.Walk(false);
            enemy_State = EnemyState.ATTACK;

            //reset the chase distane to previous
            if(chase_Distance!=current_Chase_Distance)
            {
                chase_Distance = current_Chase_Distance;
            }

        }

        //player run away from enemy
        else if(Vector3.Distance(transform.position,target.position)>chase_Distance)
        {

            //stop running
            enemy_Anim.Run(false);

            enemy_State = EnemyState.PATROL;

            //reset the patrol timer so that the function
            //can calculate the new patrol destination right away
            patrol_Timer = patrol_For_This_Time;

            //reset the chase distane to previous
            if (chase_Distance != current_Chase_Distance)
            {
                chase_Distance = current_Chase_Distance;
            }

        }//else

    }//chase

    void Attack()
    {

        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attack_Timer += Time.deltaTime;

        if(attack_Timer>wait_Before_Attack)
        {

            enemy_Anim.Attack();

            attack_Timer = 0f;

            //play attack sound

        }

        if(Vector3.Distance(transform.position,target.position)>attack_Distance+chase_After_Attack_Distance)
        {

            enemy_State = EnemyState.CHASE;

        }

    }//attack

    void SetNewRandomDestination()
    {

        float rand_Radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);       //if the new random position is outside of terrain then it will recalucalte new random position

        navAgent.SetDestination(navHit.position);

    }//for generatingf random positions

    void Turn_On_AttackPoint()
    {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint()
    {
        if (attack_Point.activeInHierarchy)
        {
            attack_Point.SetActive(false);
        }
    }

    public EnemyState Enemy_State
    {
        get; set;
        
        /*get
        {
            return enemy_State;
        }
        set
        {
            enemy_State = value;
        }*/
    }

}//class
