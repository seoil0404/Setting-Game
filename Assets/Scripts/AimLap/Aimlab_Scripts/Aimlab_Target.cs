using UnityEngine;

public class Aimlab_Target : MonoBehaviour
{
    public delegate void TargetDestroyed();
    public event TargetDestroyed OnTargetDestroyed;

    private bool isMoving = false;
    private float moveSpeed = 1.5f;
    private Vector2 direction;

    public void SetMovement(bool enableMovement, float speed)
    {
        isMoving = enableMovement;
        moveSpeed = speed;

        // ���� ���� ���� (��, ��, ��, �Ʒ� �� �ϳ�)
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0: direction = Vector2.left; break;
            case 1: direction = Vector2.right; break;
            case 2: direction = Vector2.up; break;
            case 3: direction = Vector2.down; break;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // ȭ�� ������ ������ �ʵ��� üũ
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
            {
                direction = -direction; // ���� ����
            }
        }
    }

    public void HandleHit()
    {
        OnTargetDestroyed?.Invoke();
    }

    private void OnMouseDown()
    {
        HandleHit();
    }
}
