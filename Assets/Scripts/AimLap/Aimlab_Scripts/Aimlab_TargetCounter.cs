using UnityEngine;
using TMPro;

public class Aimlab_TargetCounter : MonoBehaviour
{
    public TMP_Text targetCounterText;
    public int maxTargets = 50; // 최대 타겟 수
    private int currentCount = 0; // 현재 타겟 수

    void Start()
    {
        UpdateTargetCounter();
    }

    public void IncrementTargetCount()
    {
        if (currentCount < maxTargets)
        {
            currentCount++;
            UpdateTargetCounter();
        }
    }

    void UpdateTargetCounter()
    {
        targetCounterText.text = currentCount + " / " + maxTargets;
    }

    // 최대 타겟 수에 도달했는지 확인하는 메서드
    public bool IsTargetMaxReached()
    {
        return currentCount >= maxTargets;
    }
}
