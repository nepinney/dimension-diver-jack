using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardInputController : MonoBehaviour
{

    private InputManager input_manager;
    private KeyboardActions k_actions;

    private GameMenuButtonHandler pauseHandler;

    public void Awake()
    {
        k_actions = new KeyboardActions();
        input_manager = GameObject.Find("Input Manager").GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += RegisterPauseEvents;

        k_actions.Enable();

        k_actions.Player.Move.performed += ctx => input_manager.ActivateHorizontalMove(ctx.ReadValue<Vector2>());
        k_actions.Player.Jump.performed += ctx => input_manager.ActivatePlayerJump();
    }

    private void OnDisable()
    {
        k_actions.Disable();
        k_actions.GameState.PauseResume.performed -= ctx => pauseHandler.TogglePause();
        k_actions.Player.Move.performed -= ctx => input_manager.ActivateHorizontalMove(ctx.ReadValue<Vector2>());
        k_actions.Player.Jump.performed -= ctx => input_manager.ActivatePlayerJump();
    }

    // Once the GameUI scene is loaded, fetch the GameMenuButtonHandler to fire event when the esc key is pressed
    private void RegisterPauseEvents(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameUI" && mode == LoadSceneMode.Additive)
        {
            pauseHandler = GameObject.Find("Game UI Button Events").GetComponent<GameMenuButtonHandler>();
            k_actions.GameState.PauseResume.performed += ctx => pauseHandler.TogglePause();
        }
    }
}
