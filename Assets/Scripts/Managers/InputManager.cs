using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager>
{

    public bool enableKeyboard = true;

    // Fire events from the input manager so that other scripts can subscribe to it to get them and respond accordingly.
    // delegate means we are letting another script handle the functionality of this function
    public delegate void HorizatalMoveEvent(Vector2 direction);
    public event HorizatalMoveEvent OnHorizontalMove;

    public delegate void PlayerJumpEvent();
    public event PlayerJumpEvent OnPlayerJump;

    public GameObject player;

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += GetPlayer;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= GetPlayer;
    }

    private void Start()
    {
        SetPlayerReference();
    }

    // Since player is not persistent over multiple scenes, we need to refetch the prefab gameObject on each scene (level) load
    private void GetPlayer(Scene newScene, Scene oldScene)
    {
        SetPlayerReference();
    }

    private void SetPlayerReference()
    {
        if (!player)
        {
            player = GameObject.Find("Player");
            switch (PlayerPrefs.GetInt("layout"))
            {
                case 1:
                    player.AddComponent<TouchInputController>();
                    break;
                // Below is not needed for now as scheme #2 is on UI and scheme 3 is not yet implemented
                case 2:
                    // Add/enable touch control scheme #2
                    break;
                case 3:
                    // Add touch control scheme #3
                    break;
            }

            if (enableKeyboard) player.AddComponent<KeyboardInputController>();
        }
    }

    // Called from controllers (keyboard, touchInput)
    // Fires event which is listened for in CharacterInput to move the player using the CharacterController2D
    public void ActivateHorizontalMove(Vector2 direction)
    {
        if (OnHorizontalMove != null) OnHorizontalMove(direction);
    }

    public void ActivatePlayerJump()
    {
        if (OnPlayerJump != null) OnPlayerJump();
    }
}
