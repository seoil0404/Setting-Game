using UnityEngine;
using UnityEngine.UI;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;   // ����â �г�
    public GameObject crosshair;       // ���ؼ� ������Ʈ
    public Slider sensitivitySlider;   // ���� ���� Slider
    public Aimlab_MouseSensitivity mouseSensitivity; // ���� ���� ��ũ��Ʈ

    private bool isGamePaused = false;

    void Start()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // �����̴� �ּҰ� �� �ִ밪 ����
        if (sensitivitySlider != null)
        {
            sensitivitySlider.minValue = 0.01f;  // �ּ� ���� ��
            sensitivitySlider.maxValue = 10.0f;  // �ִ� ���� ��
            sensitivitySlider.value = mouseSensitivity.sensitivity; // �ʱⰪ ����ȭ
            sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity); // ���� ���� �̺�Ʈ ����
        }

        if (crosshair != null)
        {
            crosshair.SetActive(true); // ���ؼ� Ȱ��ȭ
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
            if (crosshair != null) crosshair.SetActive(false); // ���ؼ� ��Ȱ��ȭ
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            settingsPanel.SetActive(false);
            if (crosshair != null) crosshair.SetActive(true); // ���ؼ� Ȱ��ȭ
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void UpdateSensitivity(float value)
    {
        if (mouseSensitivity != null)
        {
            mouseSensitivity.sensitivity = value; // ���� �� ����
            
        }
    }
}
