using UnityEngine;
using TMPro;

public class Aimlab_TargetCounter : MonoBehaviour
{
    public TMP_Text targetCounterText;
    public int maxTargets = 50; // �ִ� Ÿ�� ��
    private int currentCount = 0; // ���� Ÿ�� ��

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

    // �ִ� Ÿ�� ���� �����ߴ��� Ȯ���ϴ� �޼���
    public bool IsTargetMaxReached()
    {
        return currentCount >= maxTargets;
    }
}
