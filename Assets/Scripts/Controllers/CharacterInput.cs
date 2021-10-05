using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    public CharacterController2D playerMover;
    public float speed = 35f;

    private InputManager inputManager;
    private float inputX = 0f;
    private bool jump = false;


    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        // Subscribing to the event
        inputManager.OnHorizontalMove += Move;
        inputManager.OnPlayerJump += Jump;
    }

    private void OnDisable()
    {
        // Unsubscribing from the event when the script is disabled
        inputManager.OnHorizontalMove -= Move;
        inputManager.OnPlayerJump -= Jump;
    }

    public void Move(Vector2 direction)
    {
        inputX = direction.x;
        //Debug.Log("InputX set to: " + inputX);
    }

    public void Jump()
    {
        jump = true;
    }


    void FixedUpdate()
    {
        playerMover.Move(inputX * speed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
