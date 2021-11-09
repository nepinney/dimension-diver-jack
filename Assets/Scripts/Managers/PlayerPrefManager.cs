using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Program key:
 *     initialized - {0, 1} Determines is the player prefs have been set before or not.
 * 
 * Setting keys:
 *     layout - {1, 2, 3} Determines which control layout is enabled
 *     volume - {0 - 100} Determines the set volume
 *     sfx - {0 - 100} Determines the intensity of sound effects
 *      
 * In-game keys:
 *      Shovel - {0, 1} Truth value for if the shovel has been collected
 *      Key - {0, 1} Truth value for if the key has been collected
 *      BackpackSlot1 - {"Empty", "Shovel", "Key"} Determines what is occupying slot 1
 *
 */

[DefaultExecutionOrder(-10)]
public class PlayerPrefManager : Singleton<PlayerPrefManager>
{
    public int backpackSlotCount;

    [SerializeField]
    private bool firstLoad; //TODO code for testing

    [SerializeField]
    private string[] inventoryObjectNames;
    [SerializeField]
    private GameObject[] inventoryObjectPrefabs;

    // Collection of all the prefabs of the objects used for the slots and their name 
    public Dictionary<string, GameObject> inventoryObjects;

    private void OnEnable()
    {
        inventoryObjects = new Dictionary<string, GameObject>();
        for (int i = 0; i < inventoryObjectNames.Length; i++)
        {
            inventoryObjects.Add(inventoryObjectNames[i], inventoryObjectPrefabs[i]);
        }

        // TODO CONDITIONAL CODE FOR RESETTING PLAYER PREF INFO DURING TESTING
        if (firstLoad)
        {
            SetInitialized(0);
            if (GetInitialized() == 0) DefaultPlayerPrefs();
        }
        else
        {
            SetInitialized(1);
            SkipIntroScene();
        }

        /*  TODO Code for deploying game
        if (GetInitialized() == 0)
        {
            DefaultPlayerPrefs();
            SetInitialized(1);
        } 
        else
        {
            SkipIntroScene();
        }
        */
    }

    void DefaultPlayerPrefs()
    {
        // Set default values:
        Debug.Log("Setting default player prefs...");
        SetInitialized(1);

        // Set volume to max
        SetVolume(100);

        // Set sfx to max
        SetSFX(100);

        // Set Touch control as default control
        SetControlLayout(1);

        // Set the playerprefs backpack slots to empty if not initialized
        for (int i = 0; i < backpackSlotCount; i++)
        {
            SetBackpackSlotStatus(i + 1, "Empty");
        }

        foreach (KeyValuePair<string, GameObject> kvp in inventoryObjects)
        {
            SetObjectStatus(kvp.Key, 0);
        }

        SetLevelProgress(1);

    }

    void SkipIntroScene()
    {
        SceneManager.LoadScene("Menu");
    }

    /**
     * Initialized
     */
    public int GetInitialized()
    {
        return PlayerPrefs.GetInt("initialized");
    }

    public void SetInitialized(int value)
    {
        PlayerPrefs.SetInt("initialized", value);
    }

    /**
     * Volume
     */
    public int GetVolume()
    {
        return PlayerPrefs.GetInt("volume");
    }

    public void SetVolume(float value)
    {
        PlayerPrefs.SetInt("volume", (int)Mathf.Round(value));
    }

    /**
     * SFX
     */
    public int GetSFX()
    {
        return PlayerPrefs.GetInt("sfx");
    }

    public void SetSFX(float value)
    {
        PlayerPrefs.SetInt("sfx", (int)Mathf.Round(value));
    }

    /**
     * Control Layout
     */
    public int GetControlLayout()
    {
        return PlayerPrefs.GetInt("layout");
    }

    public void SetControlLayout(int value)
    {
        //Debug.Log("Set control layout to: " + value);q
        PlayerPrefs.SetInt("layout", value);
    }

    /**
     * Inventory 2.0
     */
    public bool GetUnlockedObjectStatus(string objectName)
    {
        if (PlayerPrefs.GetInt(objectName) == 1) return true;
        else return false;
    }

    public void SetObjectStatus(string objectName, int unlocked)
    {
        PlayerPrefs.SetInt(objectName, unlocked);
    }

    /**
     * Backpack
     */
    public string GetBackpackSlotStatus(int slotNumber)
    {
        return PlayerPrefs.GetString("BackpackSlot" + slotNumber);
    }

    public void SetBackpackSlotStatus(int slotNumber, string status)
    {
        PlayerPrefs.SetString("BackpackSlot" + slotNumber, status);
    }

    /**
     * Control Layout
     */
    public int GetCurrentLevelProgress()
    {
        return PlayerPrefs.GetInt("LevelProgress");
    }

    public void SetLevelProgress(int currentLevel)
    {
        PlayerPrefs.SetInt("LevelProgress", currentLevel);
    }

    public void IncrementLevelProgress()
    {
        Debug.Log("Incrementing level progress!");
        PlayerPrefs.SetInt("LevelProgress", GetCurrentLevelProgress() + 1);
    }


}
