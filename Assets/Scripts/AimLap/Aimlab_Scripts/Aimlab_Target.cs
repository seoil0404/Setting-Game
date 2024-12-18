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

        // 랜덤 방향 설정 (왼, 오, 위, 아래 중 하나)
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

            // 화면 밖으로 나가지 않도록 체크
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
            {
                direction = -direction; // 방향 반전
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
