using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    public CharacterController2D playerMover;
    public float speed = 35f;
    public Animator animator;

    private InputManager inputManager;
    private float inputX = 0f;
    private bool jump = false;


    private void Awake()
    {
        //inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        // Subscribing to the event
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        //inputManager = InputManager.Instance;
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
        animator.SetFloat("speed", Mathf.Abs(inputX));
    }

    public void Jump()
    {
        jump = true;
        animator.SetBool("isJumping", true);
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        playerMover.Move(inputX * speed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
