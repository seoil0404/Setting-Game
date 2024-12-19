using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;     
    public Slider volumeSlider;       

    void Start()
    {
      
        if (bgmSource == null)
        {
            bgmSource = GetComponent<AudioSource>();
        }

        
        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;  
            volumeSlider.maxValue = 1f;  
            volumeSlider.value = bgmSource.volume;
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }

        
        bgmSource.Play();
    }

  
    void UpdateVolume(float value)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = value;
        }
    }
}
