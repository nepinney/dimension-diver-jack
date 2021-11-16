using UnityEngine;
using UnityEngine.UI;

public class PersistControlLayout : MonoBehaviour
{
    private PlayerPrefManager prefManager;

    public Toggle[] ControlLayoutToggles;

    private void OnEnable()
    {
        prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        if (prefManager) LoadPlayerPrefs();
    }

    void LoadPlayerPrefs()
    {
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
            }
            if (prefManager.GetControlLayout() != newLayout) prefManager.SetControlLayout(newLayout);
        }
    }

}
