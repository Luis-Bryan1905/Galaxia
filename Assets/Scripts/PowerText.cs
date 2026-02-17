using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PowerText : MonoBehaviour
{
    bool DronesSpawned = false;

    public Shooting shooting;

    TMP_Text powerText;

    public int PowerLevel;

    public GameObject Drones;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GameObject.FindGameObjectWithTag("Test").GetComponent<Shooting>();
        PowerLevel = 1;
        powerText = GetComponent<TMP_Text>();
        powerText.text = "Power: " + PowerLevel.ToString();
    }

    public void GainPowerLevel()
    {

        shooting = GameObject.FindGameObjectWithTag("Test").GetComponent<Shooting>();
        PowerLevel += 1;
        //shooting.ShipSpeed += shooting.ShipSpeed;
        Debug.Log("Speed Level Raised"); //debug to make sure medthod is called
    }

    public void SpawnDrones()
    {

        Instantiate(Drones, new Vector2(shooting.transform.position.x, shooting.transform.position.y), Quaternion.identity);

        Debug.Log("Speed Level Raised"); //debug to make sure medthod is called
    }


    // Update is called once per frame
    void Update()
    {
        powerText = GetComponent<TMP_Text>();

        if (PowerLevel <= 4)
        {
            switch (PowerLevel)
            {
                case 1:
                    shooting.LazerSpeed = 675;
                    shooting.ShootingCoolDown = 1.0f;
                    break;

                case 2:
                    shooting.LazerSpeed = 750;
                    shooting.ShootingCoolDown = 0.75f;
                    break;

                case 3:
                    shooting.LazerSpeed = 900;
                    shooting.ShootingCoolDown = 0.5f;
                    break;

                case 4:
                    shooting.LazerSpeed = 1050;
                    shooting.ShootingCoolDown = 0.25f;
                    break;

            }
            powerText.text = "Power: " + PowerLevel.ToString();
        }
        else
        {
            shooting.LazerSpeed = 1200;
            shooting.ShootingCoolDown = 0.1f;
            powerText.text = "Power: MAX";
            if (DronesSpawned == false)
            {
                SpawnDrones();
                DronesSpawned = true;
            }
        }
    }

}
