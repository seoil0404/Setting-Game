using UnityEngine;

public class TetrisLineClearCheck : MonoBehaviour
{
    private int m_partCount;

    public bool Check()
    {
        m_partCount = 0;
        for(int i =0; i<10; i++)
            transform.position += new Vector3(0.5f, 0, 0);

        if(m_partCount < 10) return false;
        else return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MinoPart"))
        {
            m_partCount++;
        }
    }
}
