using TMPro;
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

    private GameStateManager state;

    public bool enableKeyboard = true;

    public GameObject touchDebugText;
    public TextMeshProUGUI directionField;
    public TextMeshProUGUI firstTouchField;
    public TextMeshProUGUI secondTouchField;

    public GameObject buttonControls;

    public GameObject player;

   
    private void Awake()
    {
        state = GameStateManager.Instance;
    }

    private void OnEnable()
    {
        int control_layout = state.GetInt("layout");
        switch (control_layout)
        {
            case 1:
                touchDebugText.SetActive(true);
                player.AddComponent<TouchInputController>();
                buttonControls.SetActive(false);
                break;
            case 2:
                // Add/enable touch control scheme #2
                touchDebugText.SetActive(false);
                buttonControls.SetActive(true);
                break;
            case 3:
                // Add touch control scheme #3
                touchDebugText.SetActive(false);
                buttonControls.SetActive(false);
                break;
        }

        if (enableKeyboard) player.AddComponent<KeyboardInputController>();
        
    }

    private void OnDisable()
    {

        if (player != null)
        {
            KeyboardInputController key_input_controller;
            if ((key_input_controller = player.GetComponent<KeyboardInputController>()) != null)
            {
                Destroy(key_input_controller, 0f);
            }

            TouchInputController touch_input_controller;
            if ((touch_input_controller = player.GetComponent<TouchInputController>()) != null)
            {
                Destroy(touch_input_controller, 0f);
            }
        }
    }
    
    public void ActivateHorizontalMove(Vector2 direction)
    {
        if (OnHorizontalMove != null) OnHorizontalMove(direction);
    }

    public void ActivatePlayerJump()
    {
        if (OnPlayerJump != null) OnPlayerJump();
    }

    public void PausePressed(InputAction.CallbackContext context)
    {
        if (OnPausePressed != null) OnPausePressed((float)context.time);
    }



    /* Touch input way number 1
    private void Update()
    {
        if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count > 0)
        {
            foreach (UnityEngine.InputSystem.EnhancedTouch.Touch tch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
            {
                if (tch.phase == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    if (tch.screenPosition.x > Screen.width / 3 && tch.screenPosition.x < (Screen.width - (Screen.width / 3)))
                    {
                        Debug.Log("Jump start time: " + tch.phase);
                        ActivatePlayerJump();
                        break;
                    }
                }

                if (tch.screenPosition.x < Screen.width / 3)
                {
                    //Debug.Log("Screen position " + finger.screenPosition.x + " < " + Screen.width / 3);
                    Vector2 left = new Vector2(-1, 0);
                    dir = left;
                    wasTouching = true;
                    ActivateHorizontalMove(left);
                }

                if (tch.screenPosition.x > (Screen.width - (Screen.width / 3)))
                {
                    //Debug.Log("Screen position " + finger.screenPosition.x + " > " + (Screen.width - (Screen.width / 3)));
                    Vector2 right = new Vector2(1, 0);
                    dir = right;
                    wasTouching = true;
                    ActivateHorizontalMove(right);
                }
            }
        }
        else
        {
            if (wasTouching == true && dir != new Vector2(0, 0))
            {
                Vector2 still = new Vector2(0, 0);
                wasTouching = false;
                dir = still;
                ActivateHorizontalMove(still);
            }
        }
    }
    */

}
