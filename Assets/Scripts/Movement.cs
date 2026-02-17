using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float x = 0.0f;
    float y = 0.0f;

    public bool Player2 = false;

    public int ShipSpeed = 3;
    public bool MoveLeftAndRight = true;
    public bool MoveUpAndDown = false;
    public bool Enabled = true;

    public int SpeedPoints = 0;
    public int MaxSpeedPoints = 5;
    public SpeedText speedText;

    //the bounding size may need to change based upon the game. it represents the half of the width or half of the height of the sprite
    //by making it public it will appear in unity so it can be changed in the editor
    public float boundingSize = 40.0f;

    Camera GameCamera; //reference to our camera
    
    void Start() // Start is called before the first frame update
    {
        speedText = GameObject.FindGameObjectWithTag("Speed").GetComponent<SpeedText>();
        GameCamera = FindObjectOfType<Camera>();
    }


    void Update()    // Update is called once per frame
    {
        //The ShipPosition will hold the movment info of the ship
        //Every frame this number will start at 0, 0 and will update with player input
        Vector3 ShipPosition = new Vector2 (x, y);

        //The if statements will get the input from player and set the movment in the correct direction


        if (MoveUpAndDown == true)
        {      
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ShipPosition = new Vector2 (x, ShipSpeed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                ShipPosition = new Vector2(x, -ShipSpeed) * Time.deltaTime;
            }
        }

        if (Player2 == false)
        {

        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
        {
            ShipPosition = new Vector2(-ShipSpeed, y) * Time.deltaTime;
            Debug.Log("ANALOG STICK LEFT");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            ShipPosition = new Vector2(ShipSpeed, y) * Time.deltaTime;
            Debug.Log("ANALOG STICK RIGHT");
        }

        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && Player2 == true)
        {
            ShipPosition = new Vector2(-ShipSpeed, y) * Time.deltaTime;
            Debug.Log("PLAYER 2 LEFT");
        }

        if (Input.GetKey(KeyCode.RightArrow) && Player2 == true)
        {
            ShipPosition = new Vector2(ShipSpeed, y) * Time.deltaTime;
            Debug.Log("PLAYER 2 RIGHT");
        }


        //COLLISION---------------------------------------------------------------------------

        //detect the collision with the camera boundaries based on this ship's position
        //so if the ship is moving outside the boundaries, the translation will be set to 0,0
        Vector3 NewPosition = (Vector2)GameCamera.WorldToScreenPoint (transform.position + ShipPosition);// changed from original

        if (NewPosition.x + boundingSize > GameCamera.pixelWidth)
        {

            ShipPosition = new Vector2(x, y);

        }
        else if (NewPosition.x - boundingSize < 0)
        {
            ShipPosition = new Vector2(x, y);
        }

        if (NewPosition.y + boundingSize > GameCamera.pixelHeight)
        {

            ShipPosition = new Vector2(x, y);

        }
        else if (NewPosition.y - boundingSize < 0)
        {
            ShipPosition = new Vector2(x, y);
        }

        transform.Translate(ShipPosition); //apply the translation to move the ship


        if (SpeedPoints >= MaxSpeedPoints)
        {
            speedText.GainSpeedLevel();
            SpeedPoints = 0;
            Debug.Log("Speed Level = " + speedText.SpeedLevel);//debug to make sure method is called
            Debug.Log("Speed Points = " + speedText); //debug to make sure method is called
        }
    }

    //SPEED POWER UP---------------------------------------------------------------------------

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BluePowerUp"))
        {

            Destroy(other.gameObject); //Destroy the object as soon as it leaves the screen

            Debug.Log("Blue Power Up Collected"); //debug to make sure method is called

            SpeedPoints += 1;
            Debug.Log("Speed Points = " + SpeedPoints); //debug to make sure method is called

        }
    }

}
