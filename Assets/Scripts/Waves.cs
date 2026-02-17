using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{


    public int Speed;
    public GameObject Wave;
    public GameObject WaveSpawner;


    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other) 
    { 

        if((other.CompareTag("Test")))
        {
            Debug.Log("WAVE COMPLETED"); //debug to make sure medthod is called

            Instantiate(Wave);

            transform.position = new Vector3(0, 82, 0);

            //Destroy(gameObject); //Destroy the laser as soon as it leaves the screen
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, (Speed  * Time.deltaTime)));
    }
}
