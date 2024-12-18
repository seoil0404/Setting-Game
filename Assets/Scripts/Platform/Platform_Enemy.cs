using System.Collections;
using DG.Tweening;
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

    private bool isDeath = false;

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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && !isDeath)
        {
            collision.gameObject.GetComponent<Platform_Player>().ReduceHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player") && settingData.IsPlayerCanAttack)
        {
            StartCoroutine(OnDeath());
        }
    }

    IEnumerator OnDeath()
    {
        enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        enemySpriteRenderer.DOFade(0, 0.2f);
        isDeath = true;

        yield return new WaitForSeconds(0.3f);
        
        enemySpriteRenderer.DOFade(1, 0.2f);
        
        yield return new WaitForSeconds(0.3f);
        
        enemySpriteRenderer.DOFade(0, 0.2f);
        
        yield return new WaitForSeconds(0.3f);
        
        enemySpriteRenderer.DOFade(1, 0.2f);
        
        yield return new WaitForSeconds(0.3f);
        
        gameObject.SetActive(false);
    }
}
