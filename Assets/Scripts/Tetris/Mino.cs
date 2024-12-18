using NUnit.Framework.Constraints;
using System.Collections;
using System.Threading;
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

public enum Direction
{
    Up, Down, Left, Right
}

public class Mino : MonoBehaviour
{
    public float m_dropSpeed;
    public int m_dropValue;

    public float m_moveValue;

    [SerializeField] private float m_softDropTime;
    private bool m_softDrop;

    public bool m_isOn;
    [SerializeField] private MinoKind m_kind;
    private Direction m_direction;

    [SerializeField] private string m_bottomLayer;
    [SerializeField] private string m_blockLayer;
    [SerializeField] private string m_rightLayer;
    [SerializeField] private string m_leftLayer;

    [SerializeField] private GameObject m_leftCollider;
    [SerializeField] private GameObject m_rightCollider;
    [SerializeField] private GameObject m_upCollider;
    [SerializeField] private GameObject m_downCollider;
    private void Start()
    {
        StartCoroutine(drop());
        StartCoroutine(PlayerDrop());
        m_direction = Direction.Up;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S)) transform.position += new Vector3(0, -m_dropValue, 0);
        Move();
        Spin();
    }

    public void Move()
    {
        if (m_isOn)
        {
            if (Input.GetKeyDown(KeyCode.D)) transform.position += new Vector3(m_moveValue, 0, 0);
            if (Input.GetKeyDown(KeyCode.A)) transform.position += new Vector3(-m_moveValue, 0, 0);
        }
    }

    public void Spin()
    {
        if (m_isOn)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                transform.Rotate(0, 0, -90f);
                switch (m_direction)
                {
                    case Direction.Up: m_direction = Direction.Left; break;
                    case Direction.Down: m_direction = Direction.Right; break;
                    case Direction.Left: m_direction = Direction.Down; break;
                    case Direction.Right: m_direction = Direction.Up; break;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                transform.Rotate(0, 0, 90f);
                switch (m_direction)
                {
                    case Direction.Up: m_direction = Direction.Right; break;
                    case Direction.Down: m_direction = Direction.Left; break;
                    case Direction.Left: m_direction = Direction.Up; break;
                    case Direction.Right: m_direction = Direction.Down; break;
                }
            }
        }
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
        if (collision.gameObject.layer == LayerMask.NameToLayer(m_bottomLayer))
        {
            m_isOn = false;
            ColliderSet(m_direction);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer(m_blockLayer))
        {
            m_isOn = false;
            //Down();
        }
    }

    private void ColliderSet(Direction pDierction)
    {
        m_downCollider.SetActive(false);
        m_upCollider.SetActive(false);
        m_leftCollider.SetActive(false);
        m_rightCollider.SetActive(false);

        switch (pDierction)
        {
            case Direction.Right:
                {
                    m_rightCollider.SetActive(true);
                    ChangeLayer(m_rightCollider, m_blockLayer);
                    break;
                }
            case Direction.Left:
                {
                    m_leftCollider.SetActive(true);
                    ChangeLayer(m_leftCollider, m_blockLayer);
                    break;
                }
            case Direction.Up:
                {
                    m_upCollider.SetActive(true);
                    ChangeLayer(m_upCollider, m_blockLayer);
                    break;
                }
            case Direction.Down:
                {
                    m_downCollider.SetActive(true);
                    ChangeLayer(m_downCollider, m_blockLayer);
                    break;
                }
        }
    }

    void ChangeLayer(GameObject pObject, string pLayerName)
    {
        int layerIndex = LayerMask.NameToLayer(pLayerName);

        if (layerIndex == -1)
        {
            Debug.LogError("Layer name '" + pLayerName + "' does not exist.");
            return;
        }

        // 레이어 변경
        pObject.layer = layerIndex;
        Debug.Log($"Layer changed to: {pLayerName}");
    }
}

