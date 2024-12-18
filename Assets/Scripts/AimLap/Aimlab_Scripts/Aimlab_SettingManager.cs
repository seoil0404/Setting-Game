using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;   // 설정창 패널
    public GameObject crosshair;       // 조준선 오브젝트
    public Slider sensitivitySlider;   // 감도 조절 Slider
    public Aimlab_MouseSensitivity mouseSensitivity; // 감도 관리 스크립트

    private bool isGamePaused = false;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // 슬라이더 최소값 및 최대값 설정
        if (sensitivitySlider != null)
        {
            sensitivitySlider.minValue = 0.01f;  // 최소 감도 값
            sensitivitySlider.maxValue = 10.0f;  // 최대 감도 값
            sensitivitySlider.value = mouseSensitivity.sensitivity; // 초기값 동기화
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity); // 감도 변경 이벤트 연결
        }

        if (crosshair != null)
        {
            crosshair.SetActive(true); // 조준선 활성화
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0f;
            settingsPanel.SetActive(true);
            if (crosshair != null) crosshair.SetActive(false); // 조준선 비활성화
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            settingsPanel.SetActive(false);
            if (crosshair != null) crosshair.SetActive(true); // 조준선 활성화
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void UpdateSensitivity(float value)
    {
        if (mouseSensitivity != null)
        {
            mouseSensitivity.sensitivity = value; // 감도 값 적용
            
        }
    }
}
