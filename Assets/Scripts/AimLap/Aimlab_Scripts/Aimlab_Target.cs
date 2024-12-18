using UnityEngine;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetDestroyed();
    public event TargetDestroyed OnTargetDestroyed;

    public void HandleHit()
    {
        OnTargetDestroyed?.Invoke();
    }

    private void OnMouseDown()
    {
        HandleHit();
    }
}
