using UnityEngine;
using DG.Tweening;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetDestroyed();
    public event TargetDestroyed OnTargetDestroyed;

    private bool isMoving = false;
    private float moveSpeed = 1.0f; // ������ ������ �����ϱ� ���� �ӵ�

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
        // Wiggle ����
        transform.DOShakePosition(
            duration: 10f,              // ������ ���� �ð� (���� �ݺ��� ���� ū �� ����)
            strength: new Vector3(1f, 1f, 0), // �������� ���� (X, Y, Z)
            vibrato: 12,               // ���� Ƚ��
            randomness: 80,            // ������
            snapping: false,           // ��ġ�� ���� ������ ����
            fadeOut: false             // �������� ���� �� ���� ������� ȿ��
        ).SetLoops(-1, LoopType.Restart); // ���� �ݺ�
    }

    private void StopWiggle()
    {
        transform.DOKill(); // DOTween �ִϸ��̼� ����
    }

    public void HandleHit()
    {
        StopWiggle(); // Ÿ���� �ı��Ǹ� Wiggle ����
        OnTargetDestroyed?.Invoke();
    }

    private void OnMouseDown()
    {
        HandleHit();
    }
}
