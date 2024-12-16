using UnityEngine;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetClickedEvent(GameObject target);
    public event TargetClickedEvent OnTargetClicked;

    public void HandleHit()
    {
   
        OnTargetClicked?.Invoke(gameObject);
    }

    private void OnMouseDown()
    {
       
        HandleHit();
    }
}
