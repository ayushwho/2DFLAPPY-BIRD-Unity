using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip background;
    public AudioClip die;
    public AudioClip hit;
    public AudioClip point;
    public AudioClip swoosh;
    public AudioClip wing;

    void Start()
    {
        // Play background music when game starts
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();   // ✅ Capital P
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);   // ✅ Correct way for sound effects
    }
}
