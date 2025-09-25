using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleControls : MonoBehaviour
{

    private bool ballEnteredHole;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            if (ballEnteredHole == false)
            {
                ballEnteredHole = true;

                Debug.Log("Ball has entered the hole");

                ShotControl.instance.StateInHole();

                // created to call the function to display the message when the ball enters the hole
                UIPwrBarControl.instance.MsgAppear();

            }
        }
    }
}

