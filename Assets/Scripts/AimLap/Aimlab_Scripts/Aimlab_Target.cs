using UnityEngine;
using DG.Tweening;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetDestroyed();
    public event TargetDestroyed OnTargetDestroyed;

    private bool isMoving = false;
    private float moveSpeed = 1.0f; 

    void Start()
    {
        if (isMoving)
        {
            StartWiggle();
        }
    }

    public void SetMovement(bool isEnabled, float speed)
    {
        isMoving = isEnabled;
        moveSpeed = speed;

        if (isMoving)
        {
            StartWiggle();
        }
        else
        {
            StopWiggle();
        }
    }

    private void StartWiggle()
    {
    
        transform.DOShakePosition(
            duration: 10f,              
            strength: new Vector3(1f, 1f, 0), 
            vibrato: 12,               
            randomness: 80,            
            snapping: false,           
            fadeOut: false             
        ).SetLoops(-1, LoopType.Restart); 
    }

    private void StopWiggle()
    {
        transform.DOKill(); 
    }

    public void HandleHit()
    {
        StopWiggle();
        OnTargetDestroyed?.Invoke();
    }

    private void OnMouseDown()
    {
        HandleHit();
    }
}
