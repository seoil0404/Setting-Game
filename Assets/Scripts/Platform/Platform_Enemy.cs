using System.Collections;
using UnityEngine;

public class Platform_Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float directionChangeFrequency;
    [SerializeField] private float directionChangeDelay;
    [SerializeField] private MoveDirection moveDirection;

    [System.Serializable]
    public enum MoveDirection
    {
        Left, Right
    }

    private Rigidbody2D enemyRigidbody;

    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeMoveDirection());
    }

    IEnumerator ChangeMoveDirection()
    {
        enemyRigidbody.linearVelocityX = 0;

        yield return new WaitForSeconds(directionChangeDelay);

        switch (moveDirection)
        {
            case MoveDirection.Left:
                enemyRigidbody.linearVelocityX = -moveSpeed;
                break;
            case MoveDirection.Right:
                enemyRigidbody.linearVelocityX = moveSpeed;
                break;
        }

        yield return new WaitForSeconds(directionChangeFrequency);
        
        StartCoroutine(ChangeMoveDirection());
    }
}
