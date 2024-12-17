using System.Collections;
using UnityEngine;

public class Platform_Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private Platform_SettingData platformSettingData;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private Platform_GameManager gameManager;

    readonly float baseMoveSpeedMultiplier = 2.5f;
    readonly float baseJumpPowerMultiplier = 2.5f;
    readonly float toMaxJump = 0.25f; // how many wait second to get max power jump

    private int health;

    public int Health
    {
        get
        {
            return health;
        }
    }

    public bool IsStable
    {
        get
        {
            if (playerRigidbody.constraints == RigidbodyConstraints2D.FreezeRotation) return true;
            else return false;
        }
        set
        {
            if(value)
            {
                playerRigidbody.gameObject.transform.eulerAngles = Vector3.zero;
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                playerRigidbody.constraints = RigidbodyConstraints2D.None;
            }
        }
    }
    public void ReduceHealth()
    {
        health--;
        if (health == 0) gameManager.Defeat();
    }
    
    public enum JumpPadDirection
    {
        Left, Right
    }

    public void OnJumpPad()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        bool leftMove = Input.GetKey(platformSettingData.keySetting.leftMoveKey);
        bool rightMove = Input.GetKey(platformSettingData.keySetting.rightMoveKey);

        if (leftMove && rightMove)
        {
            playerRigidbody.linearVelocityX = 0;
            playerAnimator.SetBool("IsRun", false);
            return;
        }

        if (leftMove)
        {
            playerRigidbody.linearVelocityX = -platformSettingData.PlayerMoveSpeed * baseMoveSpeedMultiplier;
            playerSpriteRenderer.flipX = true;
            playerAnimator.SetBool("IsRun", true);
        }
        if (rightMove)
        {
            playerRigidbody.linearVelocityX = platformSettingData.PlayerMoveSpeed * baseMoveSpeedMultiplier;
            playerSpriteRenderer.flipX = false;
            playerAnimator.SetBool("IsRun", true);
        }

        
        if(!(leftMove || rightMove))
        {
            playerRigidbody.linearVelocityX = 0;
            playerAnimator.SetBool("IsRun", false);
        }

        if(Input.GetKeyDown(platformSettingData.keySetting.jumpKey) && !isJumping && platformSettingData.IsGravity)
        {
            isJumping = true;
            playerRigidbody.linearVelocityY = platformSettingData.PlayerJumpPower * baseJumpPowerMultiplier;
            StartCoroutine(HandleJump(0));
        }
    }

    IEnumerator HandleJump(float stack)
    {
        yield return new WaitForEndOfFrame();

        stack += Time.deltaTime;
        
        if (Input.GetKey(platformSettingData.keySetting.jumpKey) && isJumping == true)
        {
            playerRigidbody.linearVelocityY = platformSettingData.PlayerJumpPower * baseJumpPowerMultiplier;
            if(stack < toMaxJump) StartCoroutine(HandleJump(stack));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }
}
