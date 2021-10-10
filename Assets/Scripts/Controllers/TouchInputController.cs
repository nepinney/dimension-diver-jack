using TMPro;
using UnityEngine;

public class TouchInputController : MonoBehaviour
{

    private InputManager input_manager;
    private TouchScreenActions ts_actions;

    private int xDirection = 0;                             // The x componenet of the vector being sent to move the player
    private int firstTouch = 0;                             // The "role" taken on by touch 1 (1 -> left, 0 -> not active, 2 -> right, 5 -> jump)
    private int secondTouch = 0;                            // The "role" taken on by touch 2 (1 -> left, 0 -> not active, 2 -> right, 5 -> jump)

    private int left = 1;
    private int right = 2;
    private int jump = 5;
    private int waiting = -1;


    public void Awake()
    {
        input_manager = InputManager.Instance;
        ts_actions = new TouchScreenActions();
    }

    private void OnEnable()
    {
        ts_actions.Enable();
        ts_actions.Player.TouchPressOne.started += ctx => FirstTouch();
        ts_actions.Player.TouchPressOne.canceled += ctx => StopFirstTouch();
        ts_actions.Player.TouchPressTwo.started += ctx => SecondTouch();
        ts_actions.Player.TouchPressTwo.canceled += ctx => StopSecondTouch();
    }

    private void OnDisable()
    {
        ts_actions.Disable();
        ts_actions.Player.TouchPressOne.started -= ctx => FirstTouch();
        ts_actions.Player.TouchPressOne.canceled -= ctx => StopFirstTouch();
        ts_actions.Player.TouchPressTwo.performed -= ctx => SecondTouch();
        ts_actions.Player.TouchPressTwo.canceled -= ctx => StopSecondTouch();
    }

    private void FirstTouch()
    {
        Vector2 touchPosition = new Vector2(ts_actions.Player.TouchPositionOne.ReadValue<Vector2>().x, 0);
        //Debug.Log("Finger 1!" + controls.Player.TouchPositionOne.ReadValue<Vector2>());
        firstTouch = MapTouchToAction(touchPosition);
        input_manager.firstTouchField.text = "firstTouch: " + firstTouch;

    }

    private void StopFirstTouch()
    {
        // Cases:
        // First touch holding direction, second holds other direction
        // First touch start and cencel without second touch starting
        // First touch started jump, second touch start direction.

        if (firstTouch != jump && firstTouch != waiting) // if going in a direction
        {
            if (secondTouch == 0 || secondTouch == jump) // stop moving
            {
                xDirection = 0;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
            }
            else if (secondTouch != jump) // go in direction of second touch
            {
                // left or right?
                if (secondTouch == waiting) // if waiting, wants to go in same direction as first touch
                {
                    // Move player in direction of first touch - no need to activate new move
                    secondTouch = firstTouch;
                    input_manager.secondTouchField.text = "secondTouch: " + secondTouch;
                }
                else
                {
                    // go in other direction
                    if (firstTouch == right)
                    {
                        // go left
                        secondTouch = left;
                        input_manager.secondTouchField.text = "secondTouch: " + secondTouch;
                        xDirection = -1;
                        input_manager.directionField.text = "xDirection: " + xDirection;
                        input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
                    }
                    else
                    {
                        // go right
                        secondTouch = right;
                        xDirection = 1;
                        input_manager.directionField.text = "xDirection: " + xDirection;
                        input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
                    }
                }
            }
        }
        else if (firstTouch == jump)
        {
            // stop moving
            xDirection = 0;
            input_manager.directionField.text = "xDirection: " + xDirection;
            input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));

        }
        else if (firstTouch == waiting)
        {
            // do nothing
        }
        else
        {
            // do nothing
        }

        firstTouch = 0;
        input_manager.firstTouchField.text = "firstTouch: " + firstTouch;
    }

    private void SecondTouch()
    {
        Vector2 touchPosition = new Vector2(ts_actions.Player.TouchPositionTwo.ReadValue<Vector2>().x, 0);
        //Debug.Log("Finger 2!" + controls.Player.TouchPositionTwo.ReadValue<Vector2>());
        secondTouch = MapTouchToAction(touchPosition);
        input_manager.secondTouchField.text = "secondTouch: " + secondTouch;
    }

    private void StopSecondTouch()
    {

        if (secondTouch != jump) // if going in a direction
        {
            if (firstTouch == jump) // if first touch hasnt cancelled jump and second touch has cancelled moving then stop moving
            {
                xDirection = 0;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
            }
            else if (firstTouch == left) // first touch was moving left
            {
                // resume going left
                xDirection = -1;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
            }
            else if (firstTouch == right) // first touch was moving right
            {
                // resume going right
                xDirection = 1;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
            }
            else
            {
                // stop moving
                xDirection = 0;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
            }
        }
        else if (secondTouch == jump)
        {
            // do nothing
        }
        else if (secondTouch == waiting)
        {
            //do nothing
        }
        else
        {
            //do nothing
        }

        secondTouch = 0;
        input_manager.secondTouchField.text = "secondTouch: " + secondTouch;
    }

    private int MapTouchToAction(Vector2 touchPosition)
    {
        if (touchPosition.x < Screen.width / 3)
        {
            if (firstTouch != left && secondTouch != left)
            {
                xDirection -= 1;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
                return left;
            }
            else
            {
                return waiting;
            }
        }

        if (touchPosition.x > (Screen.width - (Screen.width / 3)))
        {
            if (firstTouch != right && secondTouch != right)
            {
                xDirection += 1;
                input_manager.directionField.text = "xDirection: " + xDirection;
                input_manager.ActivateHorizontalMove(new Vector2(xDirection, 0));
                return right;
            }
            else
            {
                return waiting;
            }
        }

        if (touchPosition.x > Screen.width / 3 && touchPosition.x < (Screen.width - (Screen.width / 3)))
        {
            if (firstTouch != jump && secondTouch != jump)
            {
                input_manager.ActivatePlayerJump();
                return jump;
            }
        }
        return 0;
    }
}
