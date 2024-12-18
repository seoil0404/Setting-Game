using System.Collections;
using UnityEngine;

public class Platform_Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float directionChangeFrequency;
    [SerializeField] private float directionChangeDelay;
    [SerializeField] private MoveDirection moveDirection;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;
    [SerializeField] private Platform_SettingData settingData;

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
        enemyAnimator.SetBool("IsRun", false);

        yield return new WaitForSeconds(directionChangeDelay);

        enemyAnimator.SetBool("IsRun", true);
        switch (moveDirection)
        {
            case MoveDirection.Left:

                enemyRigidbody.linearVelocityX = -moveSpeed;
                enemySpriteRenderer.flipX = false;
                moveDirection = MoveDirection.Right;
                break;
            case MoveDirection.Right:
                enemyRigidbody.linearVelocityX = moveSpeed;
                enemySpriteRenderer.flipX = true;
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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && settingData.IsPlayerCanAttack)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
