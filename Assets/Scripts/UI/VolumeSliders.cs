using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSliders : MonoBehaviour
{
    public UnityEngine.UI.Slider VolumeSlider;
    public UnityEngine.UI.Slider SFXSlider;

    void Awake() {
        LoadPlayerPrefs();
    }

    void LoadPlayerPrefs()
    {
        VolumeSlider.value = GetInt("volume");
        SFXSlider.value = GetInt("sfx");
    }

    public void SetInt(string KeyName, int Value) {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetInt(string KeyName) {
        return PlayerPrefs.GetInt(KeyName);
    }

    public void SetVolume(UnityEngine.UI.Slider obj) {
        SetInt("volume", (int)Mathf.Round(obj.value));
    }

    public void SetSFX(UnityEngine.UI.Slider obj) {
        SetInt("sfx", (int)Mathf.Round(obj.value));

    }
}
