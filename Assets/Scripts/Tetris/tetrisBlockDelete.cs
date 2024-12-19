using UnityEngine;

public class tetrisBlockDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        // 충돌한 객체의 레이어가 groundLayer에 포함되어 있는지 확인
        if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
           Destroy(collision.gameObject);
            Spawn.Instance.NewTetris();
        }
    }
}
