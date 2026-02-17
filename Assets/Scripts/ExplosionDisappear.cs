using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDisappear : MonoBehaviour
{

    public AnimationScript Anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim.currentFrame.x == 5)
        {
            Destroy(gameObject); //Destroy the object as soon as it leaves the screen
        }
    }
}
