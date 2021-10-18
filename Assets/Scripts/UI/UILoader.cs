using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    private bool gameUILoaded = false;

    void Start()
    {
        //Load the UI scene additively to whatever scene this gameObejct is attached to
        if (SceneManager.GetSceneByName("GameUI").isLoaded == false)
        {
            // Check to make sure it is not already active
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i) == SceneManager.GetSceneByName("GameUI"))
                {
                    gameUILoaded = true;
                    Debug.Log("GameUI scene was already loaded");
                }
            }

            if (!gameUILoaded)
            {
                Debug.Log("Loading GameUI scene...");
                SceneManager.LoadSceneAsync("GameUI", LoadSceneMode.Additive);
            }
        }
    }
}
