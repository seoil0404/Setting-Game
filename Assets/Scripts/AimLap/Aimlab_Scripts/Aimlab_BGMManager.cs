using UnityEngine;
using UnityEngine.UI;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;      // AudioSource ������Ʈ
    public Slider volumeSlider;       // ���� ���� �����̴�

    void Start()
    {
        // AudioSource ������Ʈ�� ������� �ʾҴٸ� �ڵ����� ã��
        if (bgmSource == null)
        {
            bgmSource = GetComponent<AudioSource>();
        }

        // �����̴� �ʱ� ����
        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;  // �ּ� ����
            volumeSlider.maxValue = 1f;  // �ִ� ����
            volumeSlider.value = bgmSource.volume; // �ʱⰪ ����ȭ
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }

        // BGM ���
        bgmSource.Play();
    }

    // �����̴� ���� ���� ���� ����
    void UpdateVolume(float value)
    {
        if (bgmSource != null)
        {
            bgmSource.volume = value;
        }
    }
}
