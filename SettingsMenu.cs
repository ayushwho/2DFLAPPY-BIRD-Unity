using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Toggle bgmToggle;
    public Toggle sfxToggle;

    void Start()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("AudioManager not found. Make sure an AudioManager exists in the Main Menu scene.");
            return;
        }

        // initialize toggles based on saved preferences
        bgmToggle.isOn = AudioManager.Instance.IsBgmOn;
        sfxToggle.isOn = AudioManager.Instance.IsSfxOn;

        // when toggles change, call AudioManager methods
        bgmToggle.onValueChanged.AddListener((value) => AudioManager.Instance.SetBGM(value));
        sfxToggle.onValueChanged.AddListener((value) => AudioManager.Instance.SetSFX(value));

        settingsPanel.SetActive(false);
    }

    public void OpenSettings() => settingsPanel.SetActive(true);
    public void CloseSettings() => settingsPanel.SetActive(false);
}
