using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public TMP_Text scoreText;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        score = 0;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString();
    }
}
