using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)  || Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene("Two_Player");
        }

                if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("Debug");
        }
    }


}
