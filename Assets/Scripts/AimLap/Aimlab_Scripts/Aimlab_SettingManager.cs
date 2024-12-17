using UnityEngine;

public class Aimlab_SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;   
    public GameObject crosshair;      
    private bool isGamePaused = false;

    void Start()
    {
        
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

    
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
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
}
