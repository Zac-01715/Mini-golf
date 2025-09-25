using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public static CameraControls instance;

    public Transform target;

    public float movingRate;

    private float rotation;

    private float verticalRotation;
    public Transform verticalCamControl;

    public float backVal = 0f;
    public float forwardVal = 84f;

    // allows the mouse to also control camera movement by using a bool
    //the directional keys are not the only way to control the camera
    public bool useMouseRotation;

    // allows the directional indicator / aim arrow to be used and created by the user
    // only before the ball is shot
    public GameObject aimArrow; 

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        verticalRotation = verticalCamControl.localRotation.eulerAngles.x;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;

        /*
        //if (rotatingMouse == false)
        {
            rotation = rotation + Input.GetAxis("Horizontal") * movingRate * Time.deltaTime;
            verticalRotation = verticalRotation + Input.GetAxis("Vertical") * movingRate * Time.deltaTime;
        }//else
        {
            rotation += Input.GetAxis("Mouse X") * movingRate * Time.deltaTime;
            verticalRotation = verticalRotation + Input.GetAxis("Mouse Y") * movingRate * Time.deltaTime;
        }
        */

        rotation = rotation + Mathf.Clamp( Input.GetAxis("Horizontal") + Input.GetAxis("Mouse X"), -1f, 1f) * movingRate * Time.deltaTime;
        verticalRotation = verticalRotation + Mathf.Clamp(Input.GetAxis("Vertical") + Input.GetAxis("Mouse Y"), -1f, 1f) * movingRate * Time.deltaTime;


        verticalRotation = Mathf.Clamp(verticalRotation, backVal, forwardVal);

        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        verticalCamControl.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
    

    public void ShowIndicator()
    {
        aimArrow.SetActive(true);
    }

    public void HideIndicator()
    {
        aimArrow.SetActive(false);
    }

}


