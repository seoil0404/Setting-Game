
using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject crosshair;
    private bool isGamePaused = false;

    [Header("Sliders for Settings")]
    public Slider sensitivitySlider;        // ���� ���� Slider
    public Slider crosshairSizeSlider;      // ���ؼ� ũ�� ���� Slider

    public Aimlab_MouseSensitivity mouseSensitivity; // ���� ���� ��ũ��Ʈ
    public Aimlab_CrosshairController crosshairController; // ���ؼ� ��ũ��Ʈ

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Slider �ʱⰪ ����
        sensitivitySlider.value = mouseSensitivity.sensitivity;
        crosshairSizeSlider.value = crosshairController.length;

        // Slider �̺�Ʈ ����
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
