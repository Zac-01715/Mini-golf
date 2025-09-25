using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCount : MonoBehaviour
{
    public static HoleCount instance;

    private void Awake()
    {
        instance = this;
    }
    // the tracking of the amount of shots will always start at zero before the shot is taken
    public int ShotCount = 0;

    //to track if the user has gone above the suggested shot limit for the hole
    public int limit;
    // Start is called before the first frame update
    void Start()
    {
        // put at the start as it needs to be shown for the whole game, for every level
        UIPwrBarControl.instance.CreateLimit(limit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeShot()
    {
        //adds 1 to shotCount for every shot thats taken
        ShotCount += 1;
        // tells the UI to update the shots text with the shot count value
        UIPwrBarControl.instance.RenewShotTrackerMsg(ShotCount);
    }
}
