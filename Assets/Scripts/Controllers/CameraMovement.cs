using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerMove;
    public float camPosOffsetx;
    public float camPosOffsety;

    // Start is called before the first frame update
    void Start()
    {
        // obtain the player object for reference
        // motion is tracked from player
        playerMove = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // camera position
        Vector3 camPosition = transform.position;

        // get the current player position
        camPosition.x = playerMove.position.x;
        camPosition.y = playerMove.position.y;

        // create an offset, obtained from unity editor
        camPosition.x += camPosOffsetx;
        camPosition.y += camPosOffsety;

        // move the camera
        transform.position = camPosition;

    }
}
