using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Add listener to the slider value change event
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Initialize the slider value to the current volume
        volumeSlider.value = AudioListener.volume;
    }

    private void OnVolumeChanged(float value)
    {
        // Update the volume of all audio sources
        AudioListener.volume = value;
    }
}