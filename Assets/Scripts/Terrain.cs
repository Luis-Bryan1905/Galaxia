using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{

    public int Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Terrain Off Screen"); //debug to make sure medthod is called

        Destroy(gameObject); //Destroy the object as soon as it leaves the screen
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, (Speed  * Time.deltaTime)));
    }
}
