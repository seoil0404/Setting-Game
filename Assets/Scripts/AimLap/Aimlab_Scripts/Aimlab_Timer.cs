using UnityEngine;
using TMPro;

public class Aimlab_Timer : MonoBehaviour
{
    public TMP_Text timerText; 
    private float timeLeft = 60f; 
    private bool timerRunning = true;

    void Start()
    {
   
        UpdateTimerText();  
    }
        
    void Update()
    {
        if (timerRunning)
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
        
            
    }
}
