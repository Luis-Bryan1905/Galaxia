using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public LivesText livesText;

    public GameObject GameOverText;

    public GameObject Explosion;

    public GameObject PlayerShip;

    public int RespawnDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<LivesText>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) //if touches enemy
        {
            Debug.Log("Player Hit"); //debug to make sure medthod is called

            Destroy(other.gameObject); //Destroy Enemy

            livesText.TakeDamage(); //Player takes Damage

           // Destroy(gameObject); //Destroy the player

            Instantiate(Explosion, transform.position, Quaternion.identity); //Spawn Explosion

            //StartCoroutine(SpawnPlayer());
        }

        if (other.CompareTag("Obstacle")) //if touches enemy
        {
            Debug.Log("Player Hit"); //debug to make sure medthod is called

            livesText.TakeDamage(); //Player takes Damage

            // Destroy(gameObject); //Destroy the player

            Instantiate(Explosion, transform.position, Quaternion.identity); //Spawn Explosion

            //StartCoroutine(SpawnPlayer());
        }
    }

    public void GameOver()
    {
        Destroy(gameObject); //Destroy the player
        Instantiate(Explosion, transform.position, Quaternion.identity); //Spawn Explosion
        Instantiate(GameOverText, transform.position, Quaternion.identity); //Spawn Game Over Text
    }

    private IEnumerator SpawnPlayer()
    {
        Debug.Log("Spawn Player"); //debug to make sure medthod is called
        Instantiate(PlayerShip, transform.position, Quaternion.identity); //Spawn Player
        Debug.Log("Player spawned"); //debug to make sure medthod is called

        yield return new WaitForSeconds(RespawnDelay);
    } 

    void Update()
    {

    }
}

