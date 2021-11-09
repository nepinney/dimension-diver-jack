using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//[DefaultExecutionOrder(-3)]
public class GameStateManager : Singleton<GameStateManager>
{
    private GameMenuButtonHandler gameButtonMenuHandler;

    private void OnEnable()
    {
        // Start the game time
        Time.timeScale = 1f;

        // Once the UI is loaded, we need the GameMenuButtonHandler script to listen for the pause and resume button clicks
        SceneManager.sceneLoaded += RegisterPauseEvents;
    }

    private void OnDisable()
    {
        // Unsubscribe from all events
        SceneManager.sceneLoaded -= RegisterPauseEvents;
        if (gameButtonMenuHandler)
        {
            gameButtonMenuHandler.OnPausePressed -= Pause;
            gameButtonMenuHandler.OnResumePressed -= Resume;
        }
    }

    private void RegisterPauseEvents(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameUI" && mode == LoadSceneMode.Additive)
        {
            gameButtonMenuHandler = GameObject.Find("Game UI Button Events").GetComponent<GameMenuButtonHandler>();
            gameButtonMenuHandler.OnPausePressed += Pause;
            gameButtonMenuHandler.OnResumePressed += Resume;
            //gameButtonMenuHandler.OnMainMenuPressed += DestroyForMenu;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        // Press "T" for quick access to load level from Hombase
        if (Input.GetKeyDown(KeyCode.T) && SceneManager.GetActiveScene().name != "Menu")
        {
            PlayerPrefManager prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
            prefManager.IncrementLevelProgress();
            LoadLevel(prefManager.GetCurrentLevelProgress());
        }
    }

    public void LoadLevel(int level)
    {
        StartCoroutine(NextLevel(level));
    }

    IEnumerator NextLevel(int levelNumber)
    {
        yield return null;
        Debug.Log("Loading level: " + levelNumber);

        //Begin to load the Scene you specify
        // TODO Save level progres, fetch next level and load
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelNumber.ToString());
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
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

    public void ReturnHome()
    {
        StartCoroutine(LoadHome());
    }

    IEnumerator LoadHome()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Homebase");

        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
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
