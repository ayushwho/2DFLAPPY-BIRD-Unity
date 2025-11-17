using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public bool IsBgmOn { get; private set; } = true;
    public bool IsSfxOn { get; private set; } = true;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetBGM(bool on)
    {
        IsBgmOn = on;
        if (musicSource != null) musicSource.mute = !on;
    }

    public void SetSFX(bool on)
    {
        IsSfxOn = on;
        if (sfxSource != null) sfxSource.mute = !on;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (IsSfxOn && sfxSource != null && clip != null)
            sfxSource.PlayOneShot(clip);
    }
}