using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public GameObject PlayerShip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerShip = GameObject.FindGameObjectWithTag("Test");
        transform.position = new Vector2(PlayerShip.transform.position.x + 0.45f, PlayerShip.transform.position.y + 0.8f);
    }
}
