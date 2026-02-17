using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{


    public bool Player2 = false;

    public Rigidbody2D LazerPrefab; // create an instance of the prefab it can be instantiated multiple times when the player shoots

    public float LazerSpeed = 675.0f; //the speed the lazer travels at

    public float ShootingCoolDown = 1.0f; //per seconds for cooldown 

    public float LastShot = 0.0f; //the time the last show was fired

    public int PowerPoints = 0;
    public int MaxPowerPoints = 5;
    public PowerText powerText;

    //lazer auido clip
    public AudioClip lazerShot;

    //the object that will manaage the audio
    AudioSource ShootingAudio;

    // Start is called before the first frame update
    void Start()
    {
        powerText = GameObject.FindGameObjectWithTag("Power").GetComponent<PowerText>();

        //set the audio source component
        ShootingAudio = GetComponent<AudioSource>();
    }

    void FireLazer()
    {
        if (Time.time - LastShot < ShootingCoolDown) //check the cooldown
        {
            return;
        }

        Rigidbody2D lazerprefab = Instantiate(LazerPrefab, new Vector2(transform.position.x, transform.position.y + 0.75f), Quaternion.identity) as Rigidbody2D; //create an instance of the lazer prefab

        lazerprefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, LazerSpeed)); // add direction to the laszer shot and and the laser speed is added to y direction so that the lazers moves up speed of 500

        LastShot = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm

        ShootingAudio.PlayOneShot(lazerShot, 10.0f);
    }



    // Update is called once per frame
    void Update()
    {

        if(Player2 == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                FireLazer();
            }
        }

        if(Player2 == true)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                FireLazer();
            }
        }



        if (PowerPoints >= MaxPowerPoints)
        {
            powerText.GainPowerLevel();
            PowerPoints = 0;
            Debug.Log("Power Level = " + powerText.PowerLevel);//debug to make sure method is called
            Debug.Log("Power Points = " + powerText); //debug to make sure method is called
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedPowerUp"))
        {

            Destroy(other.gameObject); //Destroy the object as soon as it leaves the screen

            Debug.Log("Red Power Up Collected"); //debug to make sure method is called

            PowerPoints += 1;
            Debug.Log("Power Points = " + PowerPoints); //debug to make sure method is called


        }
    }
}
