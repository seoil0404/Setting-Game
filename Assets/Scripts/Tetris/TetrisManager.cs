using System.Collections;
using UnityEngine;

public class TetrisManager : MonoBehaviour
{
    private bool m_isMino;
    private Mino m_currentMino;
    [SerializeField] Mino[] m_nextMino;

    [SerializeField] Mino m_holdMino;

    [SerializeField] GameObject[] m_Minos;
    [SerializeField]  Vector2 m_minoSpawnVec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MinoSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))SpawnMino();
    }

    public GameObject SpawnMino()
    {
        int Rand = Random.Range(0,7);
        return Instantiate(m_Minos[Rand], m_minoSpawnVec, Quaternion.identity);
    }

    private IEnumerator MinoSpawn()
    {
        while(true)
        {
            if (!m_isMino)
            {
                m_currentMino = SpawnMino().GetComponent<Mino>();
                m_isMino = true;
            }

            else if(!m_currentMino.m_isOn)
            {
                m_isMino = false;

            }
            yield return null;
        }
    }
}
