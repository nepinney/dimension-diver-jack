using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Defines a controller like below
 * _____________________
 * |     |        |    |      
 * |     |        |    |      
 * |  r  |  jump  |  l |      
 * |     |        |    |      
 * _____________________
 */
public class UserControllerOne : MonoBehaviour
{
    public int width;
    public int height;

    public float leftTouchBoundary;
    public float rightTouchBoundary;

    public CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    public bool jump = false;

    // Start is called before the first frame update
    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        Debug.Log("Width: " + width + " Height: " + height);

        leftTouchBoundary = width/5;
        rightTouchBoundary = width - width/5;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.touchCount > 0 )
    //     {
    //         foreach (Touch tch in Input.touches)
    //         {
    //             Vector2 touchPosition = tch.position;
    //             if (touchPosition.x <= leftTouchBoundary)
    //             {
    //                 if (tch.phase == TouchPhase.Began) 
    //                 {
    //                     horizontalMove += 1f;
    //                 }
    //                 else if (tch.phase == TouchPhase.Ended)
    //                 {
    //                     horizontalMove -= 1f;
    //                 }
    //             }
    //             else if (touchPosition.x >= rightTouchBoundary)
    //             {
    //                 if (tch.phase == TouchPhase.Began) 
    //                 {
    //                     horizontalMove -= 1f;
    //                 }
    //                 else if (tch.phase == TouchPhase.Ended)
    //                 {
    //                     horizontalMove += 1f;
    //                 }
    //                 // Debug.Log("Going right...");
    //             }
    //             else if (touchPosition.x > leftTouchBoundary && touchPosition.x < rightTouchBoundary)
    //             {
    //                 if (tch.phase == TouchPhase.Began) 
    //                 {
    //                     jump = true;
    //                 }
    //             }
    //             horizontalMove *= runSpeed;
    //             // Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
    //             // Debug.Log(touchPosition);
    //         }
    //     }
    // }

    public void moveLeft() {
        horizontalMove = -1f * runSpeed;
    }
    
    public void moveRight() {
        horizontalMove = 1f * runSpeed;
    }

    private void FixedUpdate() 
    {
        Debug.Log(horizontalMove);
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }
}
