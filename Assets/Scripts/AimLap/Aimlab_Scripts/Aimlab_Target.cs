using UnityEngine;
using DG.Tweening;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetDestroyed();
    public event TargetDestroyed OnTargetDestroyed;

    private bool isMoving = false;
    private float moveSpeed = 1.0f; // 움직임 강도를 조절하기 위한 속도

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
        // Wiggle 설정
        transform.DOShakePosition(
            duration: 10f,              // 움직임 지속 시간 (무한 반복을 위해 큰 값 설정)
            strength: new Vector3(1f, 1f, 0), // 움직임의 강도 (X, Y, Z)
            vibrato: 12,               // 진동 횟수
            randomness: 80,            // 랜덤성
            snapping: false,           // 위치를 정수 단위로 스냅
            fadeOut: false             // 움직임이 끝날 때 점차 사라지는 효과
        ).SetLoops(-1, LoopType.Restart); // 무한 반복
    }

    private void StopWiggle()
    {
        transform.DOKill(); // DOTween 애니메이션 종료
    }

    public void HandleHit()
    {
        StopWiggle(); // 타겟이 파괴되면 Wiggle 멈춤
        OnTargetDestroyed?.Invoke();
    }

    private void OnMouseDown()
    {
        HandleHit();
    }
}
