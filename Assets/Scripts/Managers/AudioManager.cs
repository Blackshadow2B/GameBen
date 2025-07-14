using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    // Music clips
    public AudioClip calmMusic;
    public AudioClip tenseMusic;

    // SFX clips
    // ...

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetMusicTension(float tension)
    {
        // Logic to transition between calm and tense music
    }
}
