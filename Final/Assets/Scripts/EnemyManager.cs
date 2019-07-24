using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject boar_Prefab, dragon_Prefab;

    public Transform[] dragon_SpawnPoints, boar_SpawnPoints;

    [SerializeField]
    private int dragon_Enemy_Count, boar_Enemy_Count;

    private int initial_Dragon_Count, initial_Boar_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;

    // Use this for initialization
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        initial_Dragon_Count = dragon_Enemy_Count;
        initial_Boar_Count = boar_Enemy_Count;

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void SpawnEnemies()
    {
        SpawnDragons();
        SpawnBoars();
    }

    void SpawnDragons()
    {

        int index = 0;

        for (int i = 0; i < dragon_Enemy_Count; i++)
        {

            if (index >= dragon_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(dragon_Prefab, dragon_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        dragon_Enemy_Count = 0;

    }

    void SpawnBoars()
    {

        int index = 0;

        for (int i = 0; i < boar_Enemy_Count; i++)
        {

            if (index >= boar_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(boar_Prefab, boar_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        boar_Enemy_Count = 0;

    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);

        SpawnDragons();

        SpawnBoars();

        StartCoroutine("CheckToSpawnEnemies");

    }

    public void EnemyDied(bool dragon)
    {

        if (dragon)
        {

            dragon_Enemy_Count++;

            if (dragon_Enemy_Count > initial_Dragon_Count)
            {
                dragon_Enemy_Count = initial_Dragon_Count;
            }

        }
        else
        {

            boar_Enemy_Count++;

            if (boar_Enemy_Count > initial_Boar_Count)
            {
                boar_Enemy_Count = initial_Boar_Count;
            }

        }

    }

    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnemies");
    }
}
