using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{
    // references the canvasGroup components so that the instructions screeen is loaded
    public CanvasGroup Instructions;

    // function to start the game
    // and load the first level/ first scene
    public void PlayGame()
    {
        // This gets the active scenes index 
        //and then loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // function for the instructions screen
    public void Instruction()
    {
        // makes the panel visible to the user
        // and interactive
        Instructions.alpha = 1;
        Instructions.blocksRaycasts = true;
    }
    public void Back()
    {
        // hides instruction and doesnt allow for interaction
        Instructions.alpha = 0;
        Instructions.blocksRaycasts = false;
    }
    //function which exits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
