using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public bool enableTouchDebugText = true;

    // Variables to display the debugging text
    public GameObject debugTextParent;
    public TextMeshProUGUI directionField;
    public TextMeshProUGUI firstTouchField;
    public TextMeshProUGUI secondTouchField;

    // Refrence to the UI buttons which control the player
    public GameObject buttonControls;

    // Reference to the menu components because their actions change the UI
    public GameObject gameMenu;
    public Button menuButton;
    public Button playButton;
    public GameObject pauseButton;

    // Need TouchInputController to listen to the changes to update the debug text
    private TouchInputController touchController { get; set; }
    private GameMenuButtonHandler gameMenuButtonHandler;

    private void OnEnable()
    {
        // Need to know when gameUI has finished loaded to get needed components
        SceneManager.sceneLoaded += GameUILoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from all currenlty listening events
        SceneManager.sceneLoaded -= GameUILoaded;
        gameMenuButtonHandler.OnPausePressed -= OnPause;
        gameMenuButtonHandler.OnResumePressed -= OnResume;
        if (touchController && enableTouchDebugText) touchController.OnDebugTextUpdate -= UpdateDebugText;
    }

    private void GameUILoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameUI" && mode == LoadSceneMode.Additive)
        {
            // Get the GameMenuButtonHandler to subscribe to pause events to know when to show and hide the pause menu
            gameMenuButtonHandler = GameObject.Find("Game UI Button Events").GetComponent<GameMenuButtonHandler>();
            gameMenuButtonHandler.OnPausePressed += OnPause;
            gameMenuButtonHandler.OnResumePressed += OnResume;
            InitializeGameUI();
        }
    }

    private void InitializeGameUI()
    {
        //Debug.Log("Initializing game UI");
        debugTextParent = GameObject.Find("Debug Text");
        directionField = GameObject.Find("xDirection").GetComponent<TextMeshProUGUI>();
        firstTouchField = GameObject.Find("firstTouch").GetComponent<TextMeshProUGUI>();
        secondTouchField = GameObject.Find("secondTouch").GetComponent<TextMeshProUGUI>();

        // Button Controls which are used to control the player with
        buttonControls = GameObject.Find("Button Controls");

        gameMenu = GameObject.Find("Pause Menu");
        menuButton = GameObject.Find("Menu Button").GetComponent<Button>();
        playButton = GameObject.Find("Play Button").GetComponent<Button>();
        pauseButton = GameObject.Find("Pause Button");

        // Initially set to true to get references to objects above
        gameMenu.SetActive(false);

        // Alter the UI depending on the control scheme the user has selected to control the player with
        switch (PlayerPrefs.GetInt("layout"))
        {
            case 1:
                if (enableTouchDebugText)
                {
                    touchController = GameObject.Find("Player").GetComponent<TouchInputController>();
                    touchController.OnDebugTextUpdate += UpdateDebugText;
                    debugTextParent.SetActive(true);
                }
                else debugTextParent.SetActive(false);
                buttonControls.SetActive(false);
                break;
            case 2:
                debugTextParent.SetActive(false);
                buttonControls.SetActive(true);
                break;
            case 3:
                debugTextParent.SetActive(false);
                buttonControls.SetActive(false);
                break;
        }
    }

    private void UpdateDebugText(string field, int newValue)
    {
        switch (field) {
            case "firstTouchField":
                firstTouchField.text = "firstTouch: " + newValue;
                break;
            case "secondTouchField":
                secondTouchField.text = "secondTouch: " + newValue;
                break;
            case "xDirectionField":
                directionField.text = "xDirection: " + newValue;
                break;
        }
    }

    public void OnPause()
    {
        gameMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void OnResume()
    {
        gameMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
}
