using UnityEngine;

public class Platform_JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpTime;
    [SerializeField] private Vector3 jumpDirection;

    readonly float baseJumpPowerMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Platform_Player>().OnJumpPad(jumpTime, jumpDirection * baseJumpPowerMultiplier);
        }
    }
}
