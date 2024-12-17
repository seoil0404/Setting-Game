using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public enum MinoKind
{
    I,
    J,
    O,
    T,
    L,
    S,
    Z
}

public class Mino : MonoBehaviour
{
    public float m_dropSpeed;
    public int m_dropValue;

    public float m_moveValue;

    [SerializeField] private float m_softDropTime;
    private bool m_softDrop;

    [SerializeField] private bool m_isOn;
    [SerializeField] private MinoKind m_kind;

    [SerializeField] private LayerMask m_bottomLayer;
    [SerializeField] private LayerMask m_blockLayer;

    private void Start()
    {
        StartCoroutine(drop());
        StartCoroutine(PlayerDrop());
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.S)) transform.position += new Vector3(0, -m_dropValue, 0);
        Move();

    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.D)) transform.position += new Vector3(m_moveValue, 0, 0);
        if (Input.GetKey(KeyCode.A)) transform.position += new Vector3(-m_moveValue, 0, 0);
    }

    public void SetOn(bool pOn)
    {
        m_isOn = pOn;
    }

    private void Down()
    {
        transform.position += new Vector3(0, -0.5f, 0);
    }

    private IEnumerator drop()
    {
        while (m_isOn)
        {
            if (!m_softDrop) Down();

            yield return new WaitForSeconds(m_dropSpeed);
        }

        yield break;
    }

    private IEnumerator PlayerDrop()
    {
        float curTime = 0;

        while (m_isOn)
        {
            Debug.Log("player");

            if (Input.GetKeyDown(KeyCode.S))
                Down();

            if (Input.GetKey(KeyCode.S))
            {
                if (curTime >= m_softDropTime)
                {
                    m_softDrop = true;
                    {
                        Down(); curTime = 0;
                        Debug.Log("down");
                    }
                }

                else
                {
                    curTime += Time.deltaTime;
                    Debug.Log("charging");
                }
                yield return new WaitForEndOfFrame();
            }
            else
            {
                curTime = 0;
                m_softDrop = false;
            }
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("뭐 닿임");
        Debug.Log(collision.gameObject.layer);
        Debug.Log(m_bottomLayer);
        // 충돌한 객체의 레이어가 groundLayer에 포함되어 있는지 확인
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bottom") || collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            m_isOn = false;
        }
    }

}

