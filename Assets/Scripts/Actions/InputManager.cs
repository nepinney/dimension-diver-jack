using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

// Want to make sure this singleton manager runs before any other script
[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviourSingleton<InputManager>
{
    // Fire events from the input manager so that other scripts can subscribe to it to get them and respond accordingly.
    // delegate means we are letting another script handle the functionality of this function
    public delegate void StartTouchEvent(Vector2 position, float time);
    // Event OnStartTouch of type StartTouchEvent
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;


    //private TouchControls touchControls;

    private void Awake()
    {
        //touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        //touchControls.Enable();
        //TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += FingerUp;
        
        
    }

    private void OnDisable()
    {
        //touchControls.Disable();
        //TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= FingerUp;
    }
    
    private void Start()
    {
        // Syntax to subscribe to an event and passing the event information (ctx) to the function
        // touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
         //touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);    
    }

    //private void StartTouch(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Touch started " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    //    //check if any scripts are listening before sending an event
    //    if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    //}

    //private void EndTouch(InputAction.CallbackContext context)
    //{
    //    Debug.Log("Touch ended");
    //    if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);

    //}

    private void FingerDown(Finger finger)
    {
        if (OnStartTouch != null) OnStartTouch(finger.screenPosition, Time.time);
    }

    private void FingerUp(Finger finger)
    {
        if (OnEndTouch != null) OnEndTouch(finger.screenPosition, Time.time);
    }
    //private void Update()
    //{
    //    if (UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches.Count >= 1)
    //    {
    //        Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
    //    }
    //    //foreach (UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
    //    //{
    //    //    Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
    //    //}
    //}
}
