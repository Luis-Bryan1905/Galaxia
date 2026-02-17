using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    //the frames in the animation
    public Vector2 numberOfFrames = new Vector2 (6,8);
    public Vector2 currentFrame = new Vector2(0,0);

    //size or scale of the texture
    private Vector2 size;

    //the number of frames to play per second
    public float framesPerSecond = 30.0f;

    //next frame check time
    float nextFrameTime;

    //reference to the quad
    private MeshRenderer aniRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //assign the quad's mesh Renderer to the variable
        aniRenderer = GetComponent<MeshRenderer>();

        //this wil allow an indivdual frame to fill the quad
        size = new Vector2(1.0f / numberOfFrames.x, 1.0f / numberOfFrames.y);

        //store the time + next frame change
        nextFrameTime = Time.time + (1 / framesPerSecond); // in seconds per frame

    }

    // Update is called once per frame
    void Update()
    {

        //only switch frames if the next frame time is less than the current time
        if (nextFrameTime < Time.time)
        {
            nextFrameTime = Time.time + (1 / framesPerSecond); //set new current time + seconds per frame
            currentFrame.x++;
        }

        if (currentFrame.x >= numberOfFrames.x)
        {
            //when the current x frame is more than the number of total x frames
            currentFrame.x = 0; //reset to zero
            currentFrame.y++; // and increment y frame

            if (currentFrame.y >= numberOfFrames.y)
            {
                //when the current y frame is more than the number of total y frames
                currentFrame.y = 0; //reset to zero
            }
        }

        //build offset
        //y coordinate is from the bottom of the image in OpenGL; so invert is needed
        Vector2 offSet = new Vector2(currentFrame.x * size.x, 1.0f - size.y - currentFrame.y * size.y);

        //the texture offset of the material being used on quad
        aniRenderer.material.SetTextureOffset("_MainTex", offSet);

        //the texture scale of the material being used on the quad
        aniRenderer.material.SetTextureScale("_MainTex", size); //allows it to resize it to the size of the frame

    }
}
