using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public bool directionX;
    public bool directionY;
    public float speed;
    bool moveLeft;
    bool moveDown;

    // Update is called once per frame
    void Update()
    {
        // if platform has reached max x value and is set to move in x axis,  switch direction
        if(transform.position.x > maxX && directionX == true){
            moveLeft = true;
        // if platform has reached min x value and is set to move in x axis,  switch direction
        } else if (transform.position.x < minX && directionX == true){
            moveLeft = false;

        // if platform has reached max height and is set to move in y axis,  switch direction
        } else if(transform.position.y > maxY && directionY == true){
            moveDown = true;
        // if platform has reached min height and is set to move in y axis,  switch direction
        } else if (transform.position.y < minY && directionY == true){
            moveDown = false;
        }


        // move the platform to the left by speed factor
        if (moveLeft == true && directionX == true){
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        // move the platform to the right by speed factor
        } else if (moveLeft == false && directionX == true){
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        // move the platform down by speed factor
        } else if (moveDown == true && directionY == true){
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        // move the platform up by speed factor
        } else if (moveDown == false && directionY == true){
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
    }
}
