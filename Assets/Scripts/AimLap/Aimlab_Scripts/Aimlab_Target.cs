using UnityEngine;
using DG.Tweening;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetDestroyed();
    public event TargetDestroyed OnTargetDestroyed;

    private bool isMoving = false;
    private float moveSpeed = 1.0f;

    [Header("Audio Clips")]
    public AudioSource audioSource;  
    public AudioClip hitSound;       
    public AudioClip wiggleSound;    

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
        if (audioSource != null && wiggleSound != null)
        {
            audioSource.clip = wiggleSound;
            audioSource.loop = true;
            audioSource.Play();
        }

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
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        transform.DOKill();
    }

    public void HandleHit()
    {
        StopWiggle();

        // 히트 소리 재생
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        OnTargetDestroyed?.Invoke();
    }

    private void OnMouseDown()
    {
        HandleHit();
    }
}
