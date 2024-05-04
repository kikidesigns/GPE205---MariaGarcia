using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider
    private AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Get the AudioSource component attached to this GameObject or another GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the initial value of the Slider to the current volume
        volumeSlider.value = audioSource.volume;
    }

    void Update()
    {
        // Update the AudioSource volume based on the Slider value
        audioSource.volume = volumeSlider.value;
    }
}
