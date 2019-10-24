using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public static bool canDismiss = false;
    public static bool isTappedLeft = false;
    public static bool isTappedRight = false;

    public Camera playercamera;
    [Range(0, 1)]
    public float orthoZoomSpeed;
    [Range(5, 15)]
    public float maxCameraSize;
    [Range(0, 5)]
    public float tutorialTime;

    private float initialCameraSize;
    private float accumtime = 0;

    public static bool isJumping = false;
	public static bool isGrounded = true;
    public static bool isDropping = false;
    public static bool onGround = false;
    public static bool downIsPressed = false;
    
    public static bool zoomed = false;

    private bool debugTap = false; //for debugging

    void Start () {
        initialCameraSize = playercamera.orthographicSize; 
    }

    void Awake () {
        isTappedLeft = false;
        isTappedRight = false;
    }

    void Update()
    {
        if (UiController.tutorialOn)
        {
            stopLeft(); stopRight();
            accumtime += Time.deltaTime;

            if (accumtime > tutorialTime)
            {
                canDismiss = true;
                if (Input.touchCount > 0)
                {
                    UiController.tutorialOn = false;
                    canDismiss = false;
                    accumtime = 0;
                }
                
                if (debugTap) //for debug
                {
                    UiController.tutorialOn = false;
                    canDismiss = false;
                    accumtime = 0;
                    debugTap = false;
                }
            }
        }
        
        if (zoomed)
            playercamera.orthographicSize = maxCameraSize;
        else
            playercamera.orthographicSize = initialCameraSize;
    }

    public void detectJump ()
	{
		if (isGrounded) 
			isJumping = true;	
		else
			isJumping = false;
     }

    public void detectDrop()
    {
        if (isGrounded && !onGround && !downIsPressed)
        {
            isDropping = true;
            downIsPressed = true;
            Invoke("stopDrop", 0.4f);
            Invoke("stopPress", 0.7f);
        }
    }
    
    void stopPress()
    {
        downIsPressed = false;
    }

    void stopDrop ()
    {
        isDropping = false;
    }

    public void detectLeft()
    {
        isTappedLeft = true;
    }

    public void stopLeft()
    {
        isTappedLeft = false;
    }

    public void detectRight()
    {
        isTappedRight = true;
    }

    public void stopRight()
    {
        isTappedRight = false;
    }

    public void zoomOut()
    {
        zoomed = true;
    }

    public void zoomIn()
    {
        zoomed = false;
    }

    public void tap() //for debug
    {
        debugTap = true;
    }
}
