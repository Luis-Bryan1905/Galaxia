using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedText : MonoBehaviour
{

    public Movement movement;

    TMP_Text speedText;

    public int SpeedLevel;

    // Start is called before the first frame update
    void Start()
    {
        SpeedLevel = 1;
        speedText = GetComponent<TMP_Text>();
        speedText.text = "Speed: " + SpeedLevel.ToString();
    }

    public void GainSpeedLevel()
    {

        movement = GameObject.FindGameObjectWithTag("Test").GetComponent<Movement>();
        SpeedLevel += 1;
        movement.ShipSpeed += movement.ShipSpeed;
        Debug.Log("Speed Level Raised"); //debug to make sure medthod is called
    }

    // Update is called once per frame
    void Update()
    {
        speedText = GetComponent<TMP_Text>();

        if (SpeedLevel <= 2)
        {
            speedText.text = "Speed: " + SpeedLevel.ToString();
        }
        else 
        {
            movement.ShipSpeed = 12;
            speedText.text = "Speed: MAX";
        }
    }
}
