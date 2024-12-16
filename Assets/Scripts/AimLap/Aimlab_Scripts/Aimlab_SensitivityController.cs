using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SensitivityController : MonoBehaviour
{
    public Slider sensitivitySlider; // UI 슬라이더
    public Aimlab_MouseSensitivity mouseSensitivity; // 감도 조절 클래스

    void Start()
    {
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    void UpdateSensitivity(float value)
    {
        mouseSensitivity.sensitivity = value; // 슬라이더 값으로 감도 업데이트
    }
}
