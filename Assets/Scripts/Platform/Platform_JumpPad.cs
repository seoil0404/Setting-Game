using UnityEngine;

public class Platform_JumpPad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Platform_Player>().OnJumpPad();
        }
    }
}
