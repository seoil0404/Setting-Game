using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; 
    public GameObject crosshair;     
    public Slider sensitivitySlider;  
    public Slider crosshairSizeSlider; 
    public Slider targetSizeSlider;   
    public Slider targetSpeedSlider;   
    public Toggle targetMovementToggle;

    public Aimlab_MouseSensitivity mouseSensitivity;       
    public Aimlab_CrosshairController crosshairController; 
    public Aimlab_TargetSpawner targetSpawner;            

    private bool isGamePaused = false;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

  
        if (sensitivitySlider != null)
        {
            sensitivitySlider.minValue = 0.01f;
            sensitivitySlider.maxValue = 1.0f;
            sensitivitySlider.value = mouseSensitivity.sensitivity;
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
        }

        if (crosshairSizeSlider != null)
        {
            crosshairSizeSlider.minValue = 0.1f;
            crosshairSizeSlider.maxValue = 5.0f;
            crosshairSizeSlider.value = crosshairController.length;
            crosshairSizeSlider.onValueChanged.AddListener(UpdateCrosshairSize);
        }


        if (targetSizeSlider != null)
        {
            targetSizeSlider.minValue = 0.2f;
            targetSizeSlider.maxValue = 3.0f;
            targetSizeSlider.value = targetSpawner.targetSize;
            targetSizeSlider.onValueChanged.AddListener(UpdateTargetSize);
        }

        
        if (targetSpeedSlider != null)
        {
            targetSpeedSlider.minValue = 0.1f;
            targetSpeedSlider.maxValue = 3.0f;
            targetSpeedSlider.value = targetSpawner.spawnInterval;
            targetSpeedSlider.onValueChanged.AddListener(UpdateTargetSpeed);
        }

        
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
