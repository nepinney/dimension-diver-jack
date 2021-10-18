using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuButtonHandler : MonoBehaviour
{

    public delegate void PauseGameEvent();
    public event PauseGameEvent OnPausePressed;

    public delegate void ResumeGameEvent();
    public event ResumeGameEvent OnResumePressed;

    public Button pauseButton;
    public Button playButton;
    public Button menuButton;

    private bool isPaused = false;

    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        playButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(ReturnToMenu);
    }

    public void PauseGame()
    {
        isPaused = true;
        OnPausePressed?.Invoke();
    }

    public void ResumeGame()
    {
        isPaused = false;
        OnResumePressed?.Invoke();
    }

    public void TogglePause()
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    public void ReturnToMenu()
    {
        //OnMainMenuPressed?.Invoke();
        GameObject gsManagerObject = GameObject.Find("Game State Manager");
        GameStateManager gsManagerScript = gsManagerObject.GetComponent<GameStateManager>();
        GameObject.Destroy(gsManagerScript);
        GameObject.Destroy(gsManagerObject);

        GameObject inputManagerObject = GameObject.Find("Input Manager");
        InputManager inputManagerScript = inputManagerObject.GetComponent<InputManager>();
        GameObject.Destroy(inputManagerObject);
        GameObject.Destroy(inputManagerScript);

        GameObject uiManagerObject = GameObject.Find("UIManager");
        UIManager uiManagerScript = uiManagerObject.GetComponent<UIManager>();
        GameObject.Destroy(uiManagerObject);
        GameObject.Destroy(uiManagerScript);


        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Menu");
        AsyncOperation unloadGameUI = SceneManager.UnloadSceneAsync("GameUI");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone && !unloadGameUI.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                ////Change the Text to show the Scene is ready
                //m_Text.text = "Press the space bar to continue";
                ////Wait to you press the space key to activate the Scene
                //if (Input.GetKeyDown(KeyCode.Space))
                //Activate the Scene
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
