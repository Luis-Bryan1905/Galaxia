using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDebud : MonoBehaviour
{


    public GameObject Enemy1Prefab; // create an instance of the prefab it can be instantiated multiple times when the player shoots

    public GameObject Enemy2Prefab;

    public GameObject Enemy3Prefab;

    public GameObject Enemy4Prefab;

    public GameObject Enemy5Prefab;

    public GameObject Enemy6Prefab;

    public float SpawnCoolDown = 1.0f; //per seconds for cooldown 

    public float LastSpawn = 0.0f; //the time the last enemy was spawned
    public bool DebugEnable = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    void SpawnEnemy1()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(Enemy1Prefab);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    void SpawnEnemy2()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(Enemy2Prefab);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    void SpawnEnemy3()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(Enemy3Prefab);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    void SpawnEnemy4()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(Enemy4Prefab);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    void SpawnEnemy5()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(Enemy5Prefab);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    void SpawnEnemy6()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(Enemy6Prefab);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            Debug.Log("Ship 1 Spawn");
            SpawnEnemy1();
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            Debug.Log("Ship 2 Spawn");
            SpawnEnemy2();
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            Debug.Log("Ship 3 Spawn");
            SpawnEnemy3();
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            Debug.Log("Ship 4 Spawn");
            SpawnEnemy4();
        }

        if (Input.GetKey(KeyCode.Keypad5))
        {
            Debug.Log("Meteor Spawn");
            SpawnEnemy5();
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            Debug.Log("Terrain Spawn");
            SpawnEnemy6();
        }


    }
}
