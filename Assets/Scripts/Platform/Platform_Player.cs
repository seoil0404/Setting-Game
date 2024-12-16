using System.Collections;
using UnityEngine;

public class Platform_Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Platform_SettingData platformSettingData;
    
    readonly float baseMoveSpeedMultiplier = 2.5f;
    readonly float baseJumpPowerMultiplier = 2.5f;
    readonly float toMaxJump = 0.25f; // how many wait second to get max power jump
    private bool isJumping = false;

    public bool IsStable
    {
        set
        {
            if(value)
            {
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                playerRigidbody.constraints = RigidbodyConstraints2D.None;
            }
        }
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

        if(leftMove)
        {
            playerRigidbody.linearVelocityX = -platformSettingData.PlayerMoveSpeed * baseMoveSpeedMultiplier;
        }
        if (rightMove)
        {
            playerRigidbody.linearVelocityX = platformSettingData.PlayerMoveSpeed * baseMoveSpeedMultiplier;
        }

        if (leftMove && rightMove)
        {
            playerRigidbody.linearVelocityX = 0;
        }
        if(!(leftMove || rightMove))
        {
            playerRigidbody.linearVelocityX = 0;
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
