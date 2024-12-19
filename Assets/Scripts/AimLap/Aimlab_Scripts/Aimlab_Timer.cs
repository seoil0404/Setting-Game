using UnityEngine;
using TMPro;

public class Aimlab_Timer : MonoBehaviour
{
    public TMP_Text timerText; // 타이머를 표시하는 UI 텍스트
    private float timeLeft = 60f; // 타이머의 남은 시간
    private bool timerRunning = true; // 타이머 실행 여부

    void Start()
    {
        UpdateTimerText(); // 초기 UI 업데이트
    }

    void Update()
    {
        if (timerRunning)
        {
            // 남은 시간 감소
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
        // 타이머를 화면에 표시
        timerText.text = Mathf.CeilToInt(timeLeft).ToString();
    }

    void OnTimerEnd()
    {
        // 타이머가 끝났을 때 수행할 동작 (필요 시 구현)
        Debug.Log("Timer ended!");
    }

    public void ResetTimer(float newTime)
    {
        // 타이머 초기화
        timeLeft = newTime;
        timerRunning = true;
        UpdateTimerText();
    }

    public void PauseTimer()
    {
        timerRunning = false;
    }

    public void ResumeTimer()
    {
        timerRunning = true;
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }
}
