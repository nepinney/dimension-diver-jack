using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

// Want to make sure this singleton manager runs before any other script
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    // Fire events from the input manager so that other scripts can subscribe to it to get them and respond accordingly.
    // delegate means we are letting another script handle the functionality of this function
    public delegate void PausePressedEvent(float time);
    // Event OnPausePressed of type PausePressedEvent
    public event PausePressedEvent OnPausePressed;

    public delegate void HorizatalMoveEvent(Vector2 direction);
    public event HorizatalMoveEvent OnHorizontalMove;

    public delegate void PlayerJumpEvent();
    public event PlayerJumpEvent OnPlayerJump;

    private GameControls controls;

    private GameStateManager gameController;

    private void Awake()
    {
        gameController = GameStateManager.Instance;
        controls = new GameControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.GameState.PauseResume.performed += ctx => PausePressed(ctx);
        controls.Player.Move.performed += ctx => ActivateHorizontalMove(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed += ctx => ActivatePlayerJump();

        EnhancedTouchSupport.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerUp;


    }

    private void OnDisable()
    {
        controls.Disable();
        controls.GameState.PauseResume.performed -= ctx => PausePressed(ctx);
        controls.Player.Move.performed -= ctx => ActivateHorizontalMove(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed -= ctx => ActivatePlayerJump();

        EnhancedTouchSupport.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= FingerUp;
    }

    private void ActivateHorizontalMove(Vector2 direction)
    {
        //Debug.Log("Move: " + context.ReadValue<Vector2>().x);
        if (OnHorizontalMove != null) OnHorizontalMove(direction);
    }

    private void ActivatePlayerJump()
    {
        //Debug.Log("Jump!");
        if (OnPlayerJump != null) OnPlayerJump();
    }

    private void PausePressed(InputAction.CallbackContext context)
    {
        if (OnPausePressed != null) OnPausePressed((float)context.time);
    }

    private void FingerDown(Finger finger)
    {
        // Try find tapped target
        //Vector2 worldCurrent = Camera.main.ScreenToWorldPoint(finger.screenPosition);
        //Debug.Log("World coordinate of tap: " + worldCurrent);
        //Debug.Log("Screen coordinate of tap: " + finger.screenPosition);

        if (finger.screenPosition.x < Screen.width/3)
        {
            //Debug.Log("Screen position " + finger.screenPosition.x + " < " + Screen.width / 3);
            Vector2 left = new Vector2(-1, 0);
            ActivateHorizontalMove(left);
        }

        if (finger.screenPosition.x > (Screen.width - (Screen.width / 3)))
        {
            //Debug.Log("Screen position " + finger.screenPosition.x + " > " + (Screen.width - (Screen.width / 3)));
            Vector2 right = new Vector2(1, 0);
            ActivateHorizontalMove(right);
        }

        if (finger.screenPosition.x > Screen.width / 3 && finger.screenPosition.x < (Screen.width - (Screen.width / 3)))
        {
            ActivatePlayerJump();
        }

        //Debug.Log("Got touch!");
        //Collider2D collider = Physics2D.OverlapPoint(worldCurrent, LayerMask.GetMask("Default"));
        //if (collider != null)
        //{
        //    Debug.Log("Detected collision!");

        //}
        //if (OnStartTouch != null && !GameStateManager.isPaused) OnStartTouch(finger.screenPosition, Time.time);
    }

    private void FingerUp(Finger finger)
    {
        Vector2 still = new Vector2(0, 0);
        ActivateHorizontalMove(still);
    }
    
}
