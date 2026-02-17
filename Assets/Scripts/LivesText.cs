using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesText : MonoBehaviour
{

    public HealthManager HealthM;

    public TMP_Text LiveText;

    public int lives;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        LiveText = GetComponent<TMP_Text>();
        LiveText.text = "Lives: " + lives.ToString();
    }

    public void TakeDamage()
    {
        lives -= 1;
        Debug.Log("Life Lost"); //debug to make sure medthod is called
        if (lives <= 0)
        {   
            HealthM.GameOver();
        }
    }

    public void GainLife()
    {
        lives += 1;
        Debug.Log("Life Gained"); //debug to make sure medthod is called
    }

    // Update is called once per frame
    void Update()
    {
        LiveText = GetComponent<TMP_Text>();
        LiveText.text = "Lives: " + lives.ToString();


    }
}
