using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public Rigidbody2D LazerPrefab; // create an instance of the prefab it can be instantiated multiple times when the player shoots

    public float LazerSpeed = -100.0f; //the speed the lazer travels at

    public float ShootingCoolDown = 3.0f; //per seconds for cooldown 

    public float LastShot = 0.0f; //the time the last show was fired

    float x = 0.0f;
    float y = 0.0f;
    public float ShipSpeed = 3.0f;
    public int EnemyType = 1;

    Vector3 screenPos;
    Camera ourCam;
    public float xmove;
    float width;
    public bool invert = false;

    // Start is called before the first frame update
    void Start()
    {
        ourCam = FindObjectOfType<Camera>(); //Get the camera that is used in the scene


        Vector3 ShipPosition = new Vector2 (x, y);

        width = transform.localScale.x * 100; //get the size of the screen area you will be working with

        if (invert == true)
        {
            xmove = -xmove;
        }
    }

    void FireLazer()
    {
        if (Time.time - LastShot < ShootingCoolDown) //check the cooldown
        {
            return;
        }

        Rigidbody2D lazerprefab = Instantiate(LazerPrefab, new Vector2(transform.position.x, transform.position.y - 1.0f), Quaternion.identity) as Rigidbody2D; //create an instance of the lazer prefab

        lazerprefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, LazerSpeed)); // add direction to the laszer shot and and the laser speed is added to y direction so that the lazers moves up speed of 500

        LastShot = Time.time; //Save the time to the last shot so it can be used in the cooldown algorithm

        //ShootingAudio.PlayOneShot(lazerShot, 10.0f);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Ship Off Screen"); //debug to make sure medthod is called

        Destroy(gameObject); //Destroy the laser as soon as it leaves the screen
    }

    // Update is called once per frame
    void Update()
    {
        //DebugCheck()
       transform.Translate(new Vector2(0, (ShipSpeed  * Time.deltaTime)));

        if (EnemyType == 2 || EnemyType == 4)
        {

            screenPos = ourCam.WorldToScreenPoint(transform.position);

            if (screenPos.x + (width / 2) > ourCam.pixelWidth || screenPos.x - (width / 2) < 0) //maintains ball within the x coordinates
            {
               xmove *= -1;
            }

             transform.Translate(new Vector2((xmove  * Time.deltaTime), 0));
        }

        if (EnemyType == 3 || EnemyType == 4)
        {
            FireLazer();
        }

    }
}
