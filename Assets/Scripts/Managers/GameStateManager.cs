using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameStateManager : Singleton<GameStateManager>
{

    public static bool enableKeyboard = true;

    public static bool isPaused = false;

    public GameObject pauseMenu;
    public GameObject pauseButton;

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        // Subscribing to the event
        inputManager.OnPausePressed += HandlePause;
    }

    private void OnDisable()
    {
        // Unsubscribing from the event when the script is disabled
        inputManager.OnPausePressed -= HandlePause;
    }

    void HandlePause(float time)
    {
        if (isPaused) Resume();
        else Pause();
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
