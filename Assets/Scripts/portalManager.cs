using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour
{
    public float xValue;
    public float yValue;
    public bool removeGravity;
    private GameObject playerTeleport;
    private Rigidbody2D rigidBodyPlayer;
    public AudioSource teleportSound;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Called the function");
        // get the player object
        playerTeleport = GameObject.Find("Player");
        // get the ridgidbody of the player
        rigidBodyPlayer = playerTeleport.GetComponent<Rigidbody2D>();
        // set the player position to the specified x and y values
        playerTeleport.transform.position = new Vector3(xValue, yValue, 0);

        teleportSound.Play();

        // if water level, modify rate of gravity from 3 to 1
        if(removeGravity == true){
            rigidBodyPlayer.gravityScale = 1f;
        // for non-water levels
        } else {
            rigidBodyPlayer.gravityScale = 3f;
        }
    }
}
