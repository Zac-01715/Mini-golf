using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public static ShotControl instance;

    private void Awake()
    {
        instance = this;
    }
    // ensures the ball cant be shot above the max shot power set
    // inside the inspector
    public float maximumShotPower;
    
    
    // ensures that the ball can only be shot when this statement is true
    private bool shotOn;

    //creates the game object of the ball
    private BallControlller ball;

    private float operatingShotPwr;
    public float pwrBarSpeed;
    private bool pwrIncrease;
    //made to stop the ball from being shot when its entered the hole
    private bool inHole;

    // Start is called before the first frame update
    void Start()
    {
        //shotOn = true;
        ball = FindFirstObjectByType<BallControlller>();
        //displays the power bar
        AllowShot();
        UIPwrBarControl.instance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (shotOn)
        {
            //ensures that the power bar doesnt go above the max power alotted
            if (operatingShotPwr == maximumShotPower)
            {
                pwrIncrease = false;
                // power can only increase on the slider if the power is at its minimum
            }else if (operatingShotPwr == 0f)
            {
                pwrIncrease = true;
            }

            if(pwrIncrease == true)
            {
                //mathf function moves a value to a target value
                // and makes sure it doesnt exceed the max power
                operatingShotPwr = Mathf.MoveTowards(operatingShotPwr, maximumShotPower, pwrBarSpeed * Time.deltaTime);
            }else
            {
                // represent when the slider is at its minimum shot power value (0f)
                operatingShotPwr = Mathf.MoveTowards(operatingShotPwr, 0f, pwrBarSpeed * Time.deltaTime);
            }
            // Calls the function created in the powerbar script
            //operating shows the ppower the user has chosen and this is next to the power that is the maximum 
            UIPwrBarControl.instance.SetShotPowerBar(operatingShotPwr, maximumShotPower);  

            if(Input.GetMouseButtonDown(0))
            {
                //ball.ShootBall(maximumShotPower);
                StartShot();
            }
        }
    }

    void StartShot()
    {
        ball.ShootBall(operatingShotPwr);
        //shotOn=false;
        //UIPwrBarControl.instance.HideShotPowerBar();
        StopShot();

        //function TakeShot is called into Shot Control script
        HoleCount.instance.TakeShot();
        
    }

    public void AllowShot()
    {
        if (inHole == false)
        {
            shotOn = true;
            UIPwrBarControl.instance.ShowShotPowerBar();
            UIPwrBarControl.instance.UpdateTimerUI();

            operatingShotPwr = 0f;
            pwrIncrease = true;

            UIPwrBarControl.instance.SetShotPowerBar(operatingShotPwr,maximumShotPower);
           

        }
    }

    public void StateInHole()
    {
        inHole = true;
        StopShot();
        UIPwrBarControl.instance.EndTimer();
    }

    public void StopShot()
    { 
        shotOn = false;
        //ensures that the aim arrow is turned off when the ball enters the hole
        UIPwrBarControl.instance.HideShotPowerBar();
    
        CameraControls.instance.aimArrow.SetActive(false);
    }

}



