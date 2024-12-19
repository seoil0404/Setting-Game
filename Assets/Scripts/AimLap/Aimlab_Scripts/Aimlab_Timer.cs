using UnityEngine;
using TMPro;

public class Aimlab_Timer : MonoBehaviour
{
    public TMP_Text timerText; // Ÿ�̸Ӹ� ǥ���ϴ� UI �ؽ�Ʈ
    private float timeLeft = 60f; // Ÿ�̸��� ���� �ð�
    private bool timerRunning = true; // Ÿ�̸� ���� ����

    void Start()
    {
        UpdateTimerText(); // �ʱ� UI ������Ʈ
    }

    void Update()
    {
        if (timerRunning)
        {
            // ���� �ð� ����
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
        // Ÿ�̸Ӹ� ȭ�鿡 ǥ��
        timerText.text = Mathf.CeilToInt(timeLeft).ToString();
    }

    void OnTimerEnd()
    {
        // Ÿ�̸Ӱ� ������ �� ������ ���� (�ʿ� �� ����)
        Debug.Log("Timer ended!");
    }

    public void ResetTimer(float newTime)
    {
        // Ÿ�̸� �ʱ�ȭ
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
