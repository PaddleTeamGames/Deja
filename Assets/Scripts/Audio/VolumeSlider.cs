using UnityEngine;
using UnityEngine.UI;

// Used on the volume slider on the Options Menu to control the Master Volume of the whole game
public class VolumeSlider : MonoBehaviour
{
    private const float DEFAULT_VOLUME = 0.75f;

    private static Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("MasterVolume", DEFAULT_VOLUME);
    }

    public static void SetVolume()
    {
        AudioListener.volume = slider.value;
        PlayerPrefs.SetFloat("MasterVolume", slider.value);
    }
    
    public static void GetVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", DEFAULT_VOLUME);
    }

}