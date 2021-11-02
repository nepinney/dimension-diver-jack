using UnityEngine;

public class Life : MonoBehaviour
{
    private float startx;
    private float starty;

    private float timer = 0.0f;
    private bool restart = false;
    private bool zombify = false;

    private void Awake()
    {
        startx = transform.position.x;
        starty = transform.position.y;
    }

    // When player collides with something...
    private void OnTriggerEnter2D(Collider2D col)
    {
        // If fallen off map...
        if (col.name == "Death Box")
        {
            restart = true;
            timer = 0.0f;
        }

        // If touched campfire on homebase...
        else if (col.name == "CampfireHome")
        {
            GameStateManager gsManager = GameObject.Find("Game State Manager").GetComponent<GameStateManager>();
            gsManager.LoadLevel();
        }

        // If touched campfire on levelOne...
        else if (col.name == "Campfire" || col.name == "Campfire(1)")
        {
            GameStateManager gsManager = GameObject.Find("Game State Manager").GetComponent<GameStateManager>();
            gsManager.ReturnHome();
        }

    }
    
    void FixedUpdate()
    {
        // Reset the level if restart
        if (restart == true)
        {
            timer = timer + Time.deltaTime;
            if (timer > 0.25f)
            {
                // Set player to starting position
                // TODO: define a player starting position - add object representing starting position to player prefab and pass in position to this script
                gameObject.transform.position = new Vector3(startx, starty, 0.0f);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                restart = false;
            }
        }
        else if (zombify == true)
        {
            // Start zombie mode
        }
    }

}
