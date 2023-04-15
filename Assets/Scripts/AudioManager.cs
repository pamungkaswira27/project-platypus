using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bgmClip;

    [Space]

    [SerializeField] AudioClip shootClip;
    [Range(0f, 1f)]
    [SerializeField] float shootVolume;

    [Space]

    [SerializeField] AudioClip explosionClip;
    [Range(0f, 1f)]
    [SerializeField] float explosionVolume;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayShootSFX()
    {
        PlayClip(shootClip, shootVolume);
    }

    public void PlayExplosionSFX()
    {
        PlayClip(explosionClip, explosionVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null) return;

        Vector3 camPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, camPos, volume);
    }
}
