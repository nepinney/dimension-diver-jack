using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLayout : MonoBehaviour
{
    public Toggle[] ControlLayoutToggles;

    void Awake() {
        LoadPlayerPrefs();
    }

    void LoadPlayerPrefs()
    {
        int layout = GetInt("layout");
        ControlLayoutToggles[layout-1].isOn = true;
    }

    public void SetInt(string KeyName, int Value) {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetInt(string KeyName) {
        return PlayerPrefs.GetInt(KeyName);
    }

    public void SetControlsLayout(Toggle toggle) {
        if (toggle.isOn) {
            int layout = 0;
            switch (toggle.name) {
                case "One":
                    layout = 1;
                    break;
                case "Two":
                    layout = 2;
                    break;
                case "Three":
                    layout = 3;
                    break;
            }
            SetInt("layout", layout);
        }
    }

}
