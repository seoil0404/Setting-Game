using UnityEngine;
using TMPro;

public class Aimlab_Timer : MonoBehaviour
{
    public TMP_Text timerText;       
    public GameObject gameOverUI;     
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

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        UpdateTimerText();
    }

    public void GameOver()
    {

        OnTimerEnd();
    }
}
