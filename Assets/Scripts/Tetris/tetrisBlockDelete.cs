using UnityEngine;

public class tetrisBlockDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        // �浹�� ��ü�� ���̾ groundLayer�� ���ԵǾ� �ִ��� Ȯ��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
           Destroy(collision.gameObject);
            Spawn.Instance.NewTetris();
        }
    }
}
