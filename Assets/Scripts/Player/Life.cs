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

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("GameObject1 collided with " + col.name);
        if (col.name == "Death Box")
        {
            restart = true;
            timer = 0.0f;
        }
    }
    

    void FixedUpdate()
    {
        if (restart == true)
        {
            timer = timer + Time.deltaTime;
            if (timer > 0.25f)
            {
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
