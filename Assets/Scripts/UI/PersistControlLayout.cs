using UnityEngine;
using UnityEngine.UI;

public class PersistControlLayout : MonoBehaviour
{
    public PlayerPrefManager prefManager;

    public Toggle[] ControlLayoutToggles;

    void Start() {
        prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        LoadPlayerPrefs();
    }

    void LoadPlayerPrefs()
    {
        Debug.Log("Got control layout: " + prefManager.GetControlLayout());
        ControlLayoutToggles[prefManager.GetControlLayout()-1].isOn = true;
    }

    public void SetControlsLayout(Toggle toggle) {
        if (toggle.isOn) {
            int newLayout = 0;
            switch (toggle.name) {
                case "One":
                    newLayout = 1;
                    break;
                case "Two":
                    newLayout = 2;
                    break;
                case "Three":
                    newLayout = 3;
                    break;
            }
            prefManager.SetControlLayout(newLayout);
        }
    }

}
