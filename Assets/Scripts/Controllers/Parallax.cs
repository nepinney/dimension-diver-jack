using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private Transform cameraPosition;
    private Vector3 lastStoredPosition;
    private float sizeX;
    private float sizeY;
    public Vector2 parallaxEffect;
    public float scale;
    public bool repeatY;
    public bool repeatX;

    // Start is called before the first frame update
    void Start()
    {
        // get the main camera position
        cameraPosition = Camera.main.transform;
        // store the current position
        lastStoredPosition = cameraPosition.position;

        // get the sprite, determine its size
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D backgroundImage = sprite.texture;
        sizeX = backgroundImage.width / sprite.pixelsPerUnit * scale;
        sizeY = backgroundImage.height / sprite.pixelsPerUnit * scale;
    }

    void Update()
    {

        // determine the change in camera position
        Vector3 camMove = cameraPosition.position - lastStoredPosition;

        // update the sprite using the preset parallax effect value
        transform.position += new Vector3(camMove.x * parallaxEffect.x, camMove.y * parallaxEffect.y);
        lastStoredPosition = cameraPosition.position;


        // repeat background in x direction
        if (repeatX == true){
            // if you have moved out of the size of one frame in x direction
            if (Mathf.Abs(cameraPosition.position.x - transform.position.x) >= sizeX){
                // determine how much offset is needed for new images
                float offsetPositionX = (cameraPosition.position.x - transform.position.x) % sizeX;
                // redraw images at new position (you will not see changes while game is running, smooth transition)
                transform.position = new Vector3(cameraPosition.position.x + offsetPositionX, transform.position.y);
            }
        }

        // repeat background in y direction
        if (repeatY == true){
            // if you have moved out of the size of one frame in y direction
            if (Mathf.Abs(cameraPosition.position.y - transform.position.y) >= sizeY){
                // determine how much offset is needed for new images
                float offsetPositionY = (cameraPosition.position.y - transform.position.y) % sizeY;
                // redraw images at new position (you will not see changes while game is running, smooth transition)
                transform.position = new Vector3(transform.position.x, cameraPosition.position.y + offsetPositionY);
            }
        }
    }
}
