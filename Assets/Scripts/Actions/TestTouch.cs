using UnityEngine;

public class TestTouch : MonoBehaviour
{

    private InputManager inputManager;
    private Camera cameraMain;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        // Subscribing to the event
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        // Unsubscribing from the event when the script is disabled
        inputManager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        // For z coordinate we want to put in the distance the camera has from the plane that we're trying to touch
        // We will be using the near clip plane from the camera
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);

        //Convert to world coordinates
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        transform.position = worldCoordinates;
    }
}
