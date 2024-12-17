
using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject crosshair;
    private bool isGamePaused = false;

    [Header("Sliders for Settings")]
    public Slider sensitivitySlider;        // 감도 조절 Slider
    public Slider crosshairSizeSlider;      // 조준선 크기 조절 Slider

    public Aimlab_MouseSensitivity mouseSensitivity; // 감도 관리 스크립트
    public Aimlab_CrosshairController crosshairController; // 조준선 스크립트

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Slider 초기값 설정
        sensitivitySlider.value = mouseSensitivity.sensitivity;
        crosshairSizeSlider.value = crosshairController.length;

        // Slider 이벤트 연결
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
        crosshairSizeSlider.onValueChanged.AddListener(UpdateCrosshairSize);
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
            if (crosshair != null) crosshair.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            settingsPanel.SetActive(false);
            if (crosshair != null) crosshair.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void UpdateSensitivity(float value)
    {
        mouseSensitivity.sensitivity = value;
    }

    void UpdateCrosshairSize(float value)
    {
        crosshairController.length = value;
        crosshairController.UpdateCrosshairLines();
    }
}
