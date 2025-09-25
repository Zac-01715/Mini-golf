using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlller : MonoBehaviour
{
    public static BallControlller instance;
    private void Awake()
    {
        instance = this;
    }

    public Rigidbody RB;

    public float hitPower;

    public float ballStop;
    public float speedStop = .98f;

    private new CameraControls camera;
    
    //allows a new shot to be activated
    private float noMotionCount;
    public float DelayForShot = .3f;

    // Start is called before the first frame update
    void Start()
    {
         camera = FindFirstObjectByType<CameraControls>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            RB.velocity = Vector3.forward * hitPower;

            RB.velocity = camera.transform.forward * hitPower;

            camera.HideIndicator();
        } */
        float speed = RB.velocity.magnitude;

        //Debug.Log(RB.velocity.magnitude);

        if (RB.velocity.y > -.01f)
        {
            //ball starts to decelerate 
            if (speed < ballStop)
            {
                RB.velocity = RB.velocity * speedStop;
                //ball stops moving
                if (speed < .02f)
                {
                    RB.velocity = Vector3.zero;
                    RB.angularVelocity = Vector3.zero;

                    //camera.ShowIndicator();

                    //ShotControl.instance.AllowShot();
                }
            }
        }
        //if the ball is still moving
        if (speed > .01f)
        {
            //the count will still be on 0.3
            noMotionCount = DelayForShot;
        }else
        {
            //if the ball is still for at least 0.3 seconds
            if (noMotionCount > 0f)
            {
                //0.3 seconds are being taken away at each update
                noMotionCount -= Time.deltaTime;
                if (noMotionCount <= 0f)
                {
                    camera.ShowIndicator();

                    ShotControl.instance.AllowShot();
                }
            }
        }
    }


    public void ShootBall(float maximumShotPower)
    {
        //ball wont move if this isnt there
        RB.velocity = camera.transform.forward * maximumShotPower;
        //camera.HideIndicator();

        noMotionCount = DelayForShot;
    }
}