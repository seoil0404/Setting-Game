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
                moveDirection = MoveDirection.Right;
                break;
            case MoveDirection.Right:
                enemyRigidbody.linearVelocityX = moveSpeed;
                moveDirection = MoveDirection.Left;
                break;
        }

        yield return new WaitForSeconds(directionChangeFrequency);
        
        StartCoroutine(ChangeMoveDirection());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Platform_Player>().ReduceHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
