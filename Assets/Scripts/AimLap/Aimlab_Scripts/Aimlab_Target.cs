using UnityEngine;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetClickedEvent();
    public event TargetClickedEvent OnTargetClicked;

    private void OnMouseDown()
    {
        OnTargetClicked?.Invoke(); // Ŭ���Ǿ��� �� ���� �Ŵ����� �˸�
    }
}
