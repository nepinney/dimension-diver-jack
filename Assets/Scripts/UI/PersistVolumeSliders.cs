using UnityEngine;

public class PersistVolumeSliders : MonoBehaviour
{
    public PlayerPrefManager prefManager;

    public UnityEngine.UI.Slider VolumeSlider;
    public UnityEngine.UI.Slider SFXSlider;

    void OnEnable() {
        prefManager = GameObject.Find("Player Pref Manager").GetComponent<PlayerPrefManager>();
        LoadPlayerPrefs();
    }

    void LoadPlayerPrefs()
    {
        VolumeSlider.value = prefManager.GetVolume();
        SFXSlider.value = prefManager.GetSFX();
    }

    public void SetVolume(UnityEngine.UI.Slider obj) {
        prefManager.SetVolume(obj.value);
    }

    public void SetSFX(UnityEngine.UI.Slider obj) {
        prefManager.SetSFX(obj.value);
    }
}
