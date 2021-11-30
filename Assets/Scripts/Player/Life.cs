using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    private float startx;
    private float starty;
    public AudioSource deathSound;

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
            deathSound.Play();
            restart = true;
            timer = 0.0f;
        } else if (col.tag == "spike"){
            deathSound.Play();
            restart = true;
            timer = 0.0f;
        } else if (col.name == "Level Portal")
        {
            PlayerPrefManager prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
            int currentLevel = prefManager.GetCurrentLevelProgress();
            GameStateManager gsManager = GameObject.Find("Game State Manager").GetComponent<GameStateManager>();
            gsManager.LoadLevel(currentLevel);
        }
        else if (col.name == "Home Portal")
        {
            GameStateManager gsManager = GameObject.Find("Game State Manager").GetComponent<GameStateManager>();
            gsManager.ReturnHome();
        }
        else if (col.name == "Level End Portal")
        {
            PlayerPrefManager prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
            if (SceneManager.GetActiveScene().name == prefManager.GetCurrentLevelProgress().ToString()) prefManager.IncrementLevelProgress();
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
