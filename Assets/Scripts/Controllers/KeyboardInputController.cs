using UnityEngine;

public class KeyboardInputController : MonoBehaviour
{

    private InputManager input_manager;
    private KeyboardActions k_actions;


    public void Awake()
    {
        k_actions = new KeyboardActions();
        input_manager = InputManager.Instance;
    }

    private void OnEnable()
    {
        k_actions.Enable();

        k_actions.GameState.PauseResume.performed += ctx => input_manager.PausePressed(ctx);
        k_actions.Player.Move.performed += ctx => input_manager.ActivateHorizontalMove(ctx.ReadValue<Vector2>());
        k_actions.Player.Jump.performed += ctx => input_manager.ActivatePlayerJump();
    }

    private void OnDisable()
    {
        k_actions.Disable();
        k_actions.GameState.PauseResume.performed -= ctx => input_manager.PausePressed(ctx);
        k_actions.Player.Move.performed -= ctx => input_manager.ActivateHorizontalMove(ctx.ReadValue<Vector2>());
        k_actions.Player.Jump.performed -= ctx => input_manager.ActivatePlayerJump();
    }

}
