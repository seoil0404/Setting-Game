using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;   // 설정창 패널
    public GameObject crosshair;       // 조준선 오브젝트
    public Slider sensitivitySlider;   // 감도 조절 Slider
    public Slider crosshairSizeSlider; // 조준점 크기 Slider
    public Slider targetSizeSlider;    // 타겟 크기 Slider
    public Slider targetSpeedSlider;   // 타겟 생성 속도 Slider
    public Toggle targetMovementToggle; // 타겟 움직임 토글

    public Aimlab_MouseSensitivity mouseSensitivity;       // 감도 관리 스크립트
    public Aimlab_CrosshairController crosshairController; // 조준점 관리 스크립트
    public Aimlab_TargetSpawner targetSpawner;             // 타겟 스포너

    private bool isGamePaused = false;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // 감도 슬라이더 설정
        if (sensitivitySlider != null)
        {
            sensitivitySlider.minValue = 0.01f;
            sensitivitySlider.maxValue = 1.0f;
            sensitivitySlider.value = mouseSensitivity.sensitivity;
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
        }

        // 조준점 크기 슬라이더 설정
        if (crosshairSizeSlider != null)
        {
            crosshairSizeSlider.minValue = 0.1f;
            crosshairSizeSlider.maxValue = 5.0f;
            crosshairSizeSlider.value = crosshairController.length;
            crosshairSizeSlider.onValueChanged.AddListener(UpdateCrosshairSize);
        }

        // 타겟 크기 슬라이더 설정
        if (targetSizeSlider != null)
        {
            targetSizeSlider.minValue = 0.5f;
            targetSizeSlider.maxValue = 3.0f;
            targetSizeSlider.value = targetSpawner.targetSize;
            targetSizeSlider.onValueChanged.AddListener(UpdateTargetSize);
        }

        // 타겟 속도 슬라이더 설정
        if (targetSpeedSlider != null)
        {
            targetSpeedSlider.minValue = 0.1f;
            targetSpeedSlider.maxValue = 3.0f;
            targetSpeedSlider.value = targetSpawner.spawnInterval;
            targetSpeedSlider.onValueChanged.AddListener(UpdateTargetSpeed);
        }

        // 타겟 움직임 토글 설정
        if (targetMovementToggle != null)
        {
            targetMovementToggle.isOn = targetSpawner.isMovementEnabled;
            targetMovementToggle.onValueChanged.AddListener(UpdateTargetMovement);
        }

        if (crosshair != null)
        {
            crosshair.SetActive(true);
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
        float roundedValue = Mathf.Round(value * 100f) / 100f;

        sensitivitySlider.value = roundedValue;
        mouseSensitivity.sensitivity = roundedValue;
    }


    void UpdateCrosshairSize(float value)
    {
        crosshairController.SetCrosshairSize(value);
    }

    void UpdateTargetSize(float value)
    {
        targetSpawner.targetSize = value;
    }

    void UpdateTargetSpeed(float value)
    {
        targetSpawner.spawnInterval = value;
    }

    void UpdateTargetMovement(bool isEnabled)
    {
        targetSpawner.isMovementEnabled = isEnabled;
    }
}
