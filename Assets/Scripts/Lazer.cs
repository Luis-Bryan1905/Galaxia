using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lazer : MonoBehaviour
{

    public GameObject PowerUpPrefab1; // Red
    public GameObject PowerUpPrefab2; //Blue
    public GameObject PowerUpPrefab3; //Green

  //  int randomNumber = 0;

    public Score scoreText;
    public bool PlayerLazer = true;

    // Start is called before the first frame update
    void Start()
    {
   //     PowerUpPrefab1 = GameObject.FindGameObjectWithTag("BluePowerUp");
    //    PowerUpPrefab2 = GameObject.FindGameObjectWithTag("RedPowerUp");
    //   PowerUpPrefab3 = GameObject.FindGameObjectWithTag("GreenPowerUp");

        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Lazer Deleted"); //debug to make sure medthod is called

        Destroy(gameObject); //Destroy the laser as soon as it leaves the screen
    }

void Awake()
{

}

void OnTriggerEnter2D(Collider2D other) 
{ 
    if ( other.CompareTag("Enemy") && PlayerLazer == true) 
    { 

        Debug.Log("Enemy Deleted"); //debug to make sure medthod is called

        Destroy(other.gameObject);

        Awake();

        scoreText.AddPoint();

        Destroy(gameObject); //Destroy the laser as soon as it leaves the screen

    int randomNumber = Random.Range(0, 10);

    switch (randomNumber)
    {
            case 0:
                Debug.Log("The roll is 0.");
                Instantiate(PowerUpPrefab1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 1:
                Debug.Log("The roll is 1.");
                Instantiate(PowerUpPrefab1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 2:
                 Debug.Log("The roll is 2.");
                Instantiate(PowerUpPrefab1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 3:
                 Debug.Log("The roll is 3.");
                Instantiate(PowerUpPrefab1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 4:
                 Debug.Log("The roll is 4.");
                Instantiate(PowerUpPrefab2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 5:
                Debug.Log("The roll is 5");
                Instantiate(PowerUpPrefab2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 6:
                Debug.Log("The roll is 6.");
                Instantiate(PowerUpPrefab2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 7:
                Debug.Log("The roll is 7.");
                Instantiate(PowerUpPrefab2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 8:
                Debug.Log("The roll is 8.");
                Instantiate(PowerUpPrefab3, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 9:
                Debug.Log("The roll is 9.");
                Instantiate(PowerUpPrefab3, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 10:
                Debug.Log("The roll is 10");
                Instantiate(PowerUpPrefab3, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
    }

    }


    if (other.CompareTag("Obstacle"))
    {
        Destroy(gameObject); //Destroy the laser as soon as it leaves the screen
    }

}

/////////////////////////////TO FIX (TEMPORARY)
/* 
    public GameObject scoreText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject SM = GameObject.Find("ScoreText");
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    } */

}
