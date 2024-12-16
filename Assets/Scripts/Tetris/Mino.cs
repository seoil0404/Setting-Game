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

    [SerializeField] private bool m_isOn;
    [SerializeField] private MinoKind m_kind;

    private void Start()
    {
        //StartCoroutine(drop());
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.S)) transform.position += new Vector3(0, -m_dropValue, 0);
        if(Input.GetKeyUp(KeyCode.D)) transform.position += new Vector3(m_moveValue, 0, 0);
        if(Input.GetKeyUp(KeyCode.A)) transform.position += new Vector3(-m_moveValue, 0, 0);
        
    }

    public void SetOn(bool pOn)
    {
        m_isOn = pOn;
    }

    private IEnumerator drop()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_dropSpeed);
            transform.position += new Vector3(0, -m_dropValue, 0);

        }        

        yield break;
    }
}

