using UnityEngine;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetClickedEvent();
    public event TargetClickedEvent OnTargetClicked;

    private void OnMouseDown()
    {
        OnTargetClicked?.Invoke(); // 클릭되었을 때 스폰 매니저에 알림
    }
}
