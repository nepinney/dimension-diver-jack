using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private PlayerPrefManager prefManager;
    public GameObject[] levelCollectables;

    private void OnEnable()
    {
        prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        if (prefManager.GetUnlockedObjectStatus("Shovel")) GameObject.Find("Shovel").SetActive(false);
        if (prefManager.GetUnlockedObjectStatus("Key")) GameObject.Find("Key").SetActive(false);
    }
}