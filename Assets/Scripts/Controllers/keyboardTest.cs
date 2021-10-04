using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardTest : MonoBehaviour
{
    public CharacterController2D playerMover;
    public float speed = 35f;
    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        // in unity arrow or a and d are used for horizontal movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        // In unity space is reffered to as the jump key
        if (Input.GetButtonDown("Jump")){
            // begin jumping for player
            jump = true;
        }
    }

    // call after update
    void FixedUpdate(){
        // move the player by horizontal distance and vertical if jumping
        playerMover.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        // stop player from jumping
        jump = false;
    }


}