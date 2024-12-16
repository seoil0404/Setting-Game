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
    [SerializeField] private float m_dropValue;
    [SerializeField] private float m_dropSpeed;

    [SerializeField] private float m_moveValue;

    [SerializeField] private float m_softDropTime;
    [SerializeField] private bool m_softDrop;

    [SerializeField] private bool m_isOn;
    [SerializeField] private MinoKind m_kind;

    private void Start()
    {
        StartCoroutine(drop());
        StartCoroutine(PlayerDrop());
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.S)) transform.position += new Vector3(0, -m_dropValue, 0);
        if (Input.GetKey(KeyCode.D)) transform.position += new Vector3(m_moveValue, 0, 0);
        if (Input.GetKey(KeyCode.A)) transform.position += new Vector3(-m_moveValue, 0, 0);
    }

    public void SetOn(bool pOn)
    {
        m_isOn = pOn;
    }

    private IEnumerator drop()
    {
        while (m_isOn)
        {
            yield return new WaitForSeconds(m_dropSpeed);

            if(!m_softDrop)
            transform.position += new Vector3(0, -m_dropValue, 0);
        }

        yield break;
    }

    private IEnumerator PlayerDrop()
    {
        float curTime = 0;

        while (m_isOn)
        {
            if(Input.GetKeyDown(KeyCode.S))
                transform.position += new Vector3(0, -m_dropValue, 0);

            if (Input.GetKey(KeyCode.S))
            {
                if (curTime >= m_softDropTime)
                {
                    m_softDrop = true;
                    {
                        transform.position += new Vector3(0, -m_dropValue, 0);
                        curTime = 0;
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
}

