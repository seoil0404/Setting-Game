using UnityEngine;
using TMPro;

public class Aimlab_TargetCounter : MonoBehaviour
{
    public TMP_Text targetCounterText;
    public int maxTargets = 50;
    private int currentCount = 0; 

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

    private void UpdateTargetCounter()
    {
        targetCounterText.text = currentCount + " / " + maxTargets;
    }
}
