using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDebug : MonoBehaviour
{
  
public GameObject PowerUpPrefab1; // Red

public GameObject PowerUpPrefab2; //Blue

public GameObject PowerUpPrefab3; //Green

    public float SpawnCoolDown = 1.0f; //per seconds for cooldown 

    public float LastSpawn = 0.0f; //the time the last PowerUp was spawned
    public bool DebugEnable = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    void SpawnPowerUpRed()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(PowerUpPrefab1);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }

    void SpawnPowerUpBlue()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(PowerUpPrefab2);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }


    void SpawnPowerUpGreen()
    {
        if (Time.time - LastSpawn < SpawnCoolDown) //check the cooldown
        {
            return;
        }

        Instantiate(PowerUpPrefab3);

        LastSpawn = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm
    }


    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("Red PowerUp Spawn");
                SpawnPowerUpRed();
            }

            if (Input.GetKey(KeyCode.B))
            {
                Debug.Log("Blue PowerUp Spawn");
                SpawnPowerUpBlue();
            }

            if (Input.GetKey(KeyCode.G))
            {
                Debug.Log("Green PowerUp Spawn");
                SpawnPowerUpGreen();
            }
    }
}
