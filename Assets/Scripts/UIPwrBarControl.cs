using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//gives access the unity user interfaces
using UnityEngine.UI;
public class UIPwrBarControl : MonoBehaviour
{
    public static UIPwrBarControl instance;
    private void Awake()
    {
        instance = this;

    }
    public Slider powerBar;


    public GameObject HoleEnteredMsg;
    // gains access to the text mesh pro which shows the Shot tracker UI
    public TMP_Text ShotTrackerMsg;
    //gains access to the par text created
    public TMP_Text ShotLimitMsg;
    //gains access to the countdown timer
    public GameObject TimerText;
    //accesses the on par text in TMP
    public GameObject OnParText;

    
    // timertext varible is created
    [SerializeField] private TextMeshProUGUI timerText;
    private float remainingTime = 13f;
    private bool count = true;

    // Start is called before the first frame update
    void Start()
    {
        if (timerText = null)
        {
            timerText = FindAnyObjectByType<TextMeshProUGUI>();
            if (timerText != null)
            {
                Debug.LogError("No TMPGUI here");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the timer isnt acitve it returns
        if (count == false)
        {
            Debug.LogError("TimerText not assigned");
            return;
        }

        // time gets updated
        remainingTime -= Time.deltaTime;

        UpdateTimerUI();
        //stops the timer when it reaches 0
        if (remainingTime <= 0)
        {
            EndTimer();
        }
    }

    public void ShowShotPowerBar()
    {
        // allows the powerbar to be shown
        powerBar.gameObject.SetActive(true);
    }
    // function to create the power bar which shows the current power on the slider 
    // and the maximum power on the right side of the slider
    public void SetShotPowerBar(float currentPower, float maxPower)
    {
        powerBar.maxValue = maxPower;
        powerBar.value = currentPower;
    }

    public void HideShotPowerBar()
    {
        //alows the powerbar to be hidden when the shot has been taken.
        powerBar.gameObject.SetActive(false);
    }

    // Function MsgAppear is used to show the message on the screen when ball enters hole
    public void MsgAppear()
    {
        // The message can now appear on the screen. SetActive used as its already a game object
        HoleEnteredMsg.SetActive(true);
    }

    // the limit or par is created to appear on the screen
    public void CreateLimit(int currentlimit)
    {
        if (ShotLimitMsg != null)
        {
            //.text allows the text box within the shot tracker
            // "Par: " creates a string to output to the screen and current limit is added to the end of par
            ShotLimitMsg.text = "Par: " + currentlimit;
        }
    }
    // function 'RenewShotTrackerMsg' is created so that when a shot is taken,
    //the shot tracker can update or be renewed at each shot
    public void RenewShotTrackerMsg(int currentShot)
    {
        // if statement is used to check if the user has taken the shot
        if (ShotTrackerMsg != null)
        {
            //.text allows the text box within the shot tracker
            // "Shots: " creates a string to output to the screen and string concatenation is used to add onto the end of shots
            ShotTrackerMsg.text = "Shots: " + currentShot;
        }
    }

    public void EndTimer()
    {
        count = false;
        remainingTime = 0f;
        //displays message to say that time is up
        //if the user didnt get the ball in the hole
        Debug.Log("Time Up!");
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        // changes the colour to red if there is 3 seconds left
        // shows urgency to user
        if (remainingTime > 0 && remainingTime < 3)
        {
            timerText.color = Color.red;
        }
        //handles the formatting to show minutes and seconds
        TimeSpan t = TimeSpan.FromSeconds(remainingTime);
        timerText.text = t.ToString(@"mm\:ss");
    }
    // function for the on par message
    // sees if the current shot is equal to the current limit
    public void OnParMsg(int currentShot, int currentlimit)
    {
        if (currentShot == currentlimit && OnParText != null)
        {
            OnParText.gameObject.SetActive(true);
        }
    }


}