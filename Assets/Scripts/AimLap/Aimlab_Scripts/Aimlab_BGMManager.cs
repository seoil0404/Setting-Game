using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;      // AudioSource 컴포넌트
    public Slider volumeSlider;       // 볼륨 조절 슬라이더

    void Start()
    {
        // AudioSource 컴포넌트가 연결되지 않았다면 자동으로 찾음
        if (bgmSource == null)
        {
            bgmSource = GetComponent<AudioSource>();
        }

        // 슬라이더 초기 설정
        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;  // 최소 볼륨
            volumeSlider.maxValue = 1f;  // 최대 볼륨
            volumeSlider.value = bgmSource.volume; // 초기값 동기화
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }

        // BGM 재생
        bgmSource.Play();
    }

    // 슬라이더 값에 따라 볼륨 조정
    void UpdateVolume(float value)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = value;
        }
    }
}
