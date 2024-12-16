using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public int width = 10;
    public int height = 20;

    private bool[,] grid;

    [SerializeField] private Vector2[] m_widthline;
    [SerializeField] private Vector2[] m_heightline;

    public GameObject[] m_gameObject;
    void Start()
    {
        grid = new bool[width, height];
    }


    void Update()
    {
        //   Debug.DrawLine(new Vector3(m_widthline[0].x, m_heightline[i].y), new Vector3(m_widthline[m_heightline.Length - 1].x, m_heightline[i].y), Color.red);
        //for (int i = 0; i < m_heightline.Length; i++)
        //{
        //    m_gameObject[i].transform.position = new Vector3(m_widthline[m_widthline.Length - 1].x, m_heightline[i].y),new Vector3(m_widthline[0].x, m_heightline[i].y);
        //}
        for (int i = 0; i < m_heightline.Length; i++)
            Debug.DrawLine(new Vector3(m_widthline[m_widthline.Length - 1].x, m_heightline[i].y), new Vector3(m_widthline[0].x, m_heightline[i].y),Color.black);
        for (int i = 0; i < m_widthline.Length; i++)
            Debug.DrawLine(new Vector3(m_widthline[i].x, m_heightline[m_heightline.Length - 1].y), new Vector3(m_widthline[i].x, m_heightline[0].y),Color.black);

    }

    void AddBlock(int pX, int pY)
    {

    }
}
