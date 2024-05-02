using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public Slider sfxVolumeSlider;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    public AudioClip tankFireClip, tankDeathClip, bulletHitClip, powerupClip, buttonClickClip, spawnClip;

    [Range(0f, 1f)]
    public float sfxVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("AudioManager: Trying to play a null audio clip!");
            return;
        }

        Debug.Log($"AudioManager: Playing sound effect {clip.name} at volume {sfxVolume}");
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, sfxVolume);
    }

    public void UpdateSFXVolume(float value)
    {
        sfxVolume = value;
    }
}
