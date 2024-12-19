using UnityEngine;
using TMPro;

public class Aimlab_Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject settingsPanel;
    public GameObject gameOverUI;    
    public GameObject crosshair;
    public GameObject timerUI;
    public GameObject targetUI;
    public GameObject ammoUI;
    public GameObject gameClearUI;
    private float timeLeft = 60f;     
    private bool timerRunning = true;  
    private bool isGameOver = false;    

    void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); 
        }

        UpdateTimerText();
    }

    void Update()
    {
        if (timerRunning && !isGameOver)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = 0;         
                timerRunning = false; 
                OnTimerEnd();         
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        
        timerText.text = Mathf.CeilToInt(timeLeft).ToString();
    }

    void OnTimerEnd()
    {
        
        isGameOver = true;
        Time.timeScale = 0f;

 
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        if (crosshair != null)
        {
            crosshair.SetActive(false);
        }

        
        if (crosshair != null) crosshair.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (timerUI != null) timerUI.SetActive(false);
        if (targetUI != null) targetUI.SetActive(false);
        if (ammoUI != null) ammoUI.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Debug.Log("Game Over: Timer Ended");
    }


    public void Retry()
    {
       
        Time.timeScale = 1f;  
        isGameOver = false;   
        timerRunning = true;   
        timeLeft = 60f;       

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (crosshair != null)
        {
            crosshair.SetActive(true);
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        UpdateTimerText();
    }

    public void GameOver()
    {

        OnTimerEnd();
    }
}
