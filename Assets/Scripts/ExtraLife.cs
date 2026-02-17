using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public int LifePoints = 0;

    int MaxLifePoints = 5;

    public LivesText livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<LivesText>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GreenPowerUp"))
        {

            Destroy(other.gameObject); //Destroy the object as soon as it leaves the screen

            Debug.Log("Green Power Up Collected"); //debug to make sure method is called

            LifePoints += 1;
            Debug.Log("Life Points = " + LifePoints); //debug to make sure method is called

        }
    }


        // Update is called once per frame
    void FixedUpdate()
    {


        if (LifePoints >= MaxLifePoints)
        {
            livesText.GainLife();
            LifePoints = 0;
            Debug.Log("Extra Life");
            Debug.Log("Lives = " + livesText.lives);//debug to make sure method is called
            Debug.Log("Life Points = " + LifePoints); //debug to make sure method is called
        }
    }

}
