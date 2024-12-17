using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public static TetrisGrid Instance;

    public int width = 10;
    public int height = 20;

    private Transform[,] grid;

    [SerializeField] private Vector2[] m_widthLineVec;
    [SerializeField] private Vector2[] m_heightLineVec;

    [SerializeField] private GameObject m_widthLine;
    [SerializeField] private GameObject m_heightLine;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        grid = new Transform[width, height]; // 2D 배열 초기화
    }

    void Start()
    {
        //grid = new bool[width, height]; 
        for (int i = 0; i < m_heightLineVec.Length; i++)
        {
            Instantiate(m_heightLine, new Vector3(0, m_heightLineVec[i].y), Quaternion.identity);
            //Debug.DrawLine(new Vector3(m_widthLineVec[m_widthLineVec.Length - 1].x, m_heightLineVec[i].y), new Vector3(m_widthLineVec[0].x, m_heightLineVec[i].y), Color.black);
        }
        for (int i = 0; i < m_widthLineVec.Length; i++)
        {
            Instantiate(m_widthLine, new Vector3(m_widthLineVec[i].x, 0), m_widthLine.transform.rotation);

            //Debug.DrawLine(new Vector3(m_widthLineVec[i].x, m_heightLineVec[m_heightLineVec.Length - 1].y), new Vector3(m_widthLineVec[i].x, m_heightLineVec[0].y), Color.black);
        }
    }


    void Update()
    {
        //   Debug.DrawLine(new Vector3(m_widthline[0].x, m_heightline[i].y), new Vector3(m_widthline[m_heightline.Length - 1].x, m_heightline[i].y), Color.red);
        //for (int i = 0; i < m_heightline.Length; i++)
        //{
        //    m_gameObject[i].transform.position = new Vector3(m_widthline[m_widthline.Length - 1].x, m_heightline[i].y),new Vector3(m_widthline[0].x, m_heightline[i].y);
        //}
        for (int i = 0; i < m_heightLineVec.Length; i++)
        {
            //Instantiate(m_heightLine, new Vector3(0, m_heightLineVec[i].y), Quaternion.identity);
            Debug.DrawLine(new Vector3(m_widthLineVec[m_widthLineVec.Length - 1].x, m_heightLineVec[i].y), new Vector3(m_widthLineVec[0].x, m_heightLineVec[i].y),Color.black);
        }
        for (int i = 0; i < m_widthLineVec.Length; i++)
        {
           //    Instantiate(m_widthLine, new Vector3(m_widthLineVec[i].x, 0), Quaternion.identity);

            Debug.DrawLine(new Vector3(m_widthLineVec[i].x, m_heightLineVec[m_heightLineVec.Length - 1].y), new Vector3(m_widthLineVec[i].x, m_heightLineVec[0].y),Color.black);
        }

    }

    private Vector2 RoundToGrid(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
    public void SaveBlockToGrid(Transform block)
    {
        foreach (Transform tile in block)
        {
            Vector2 pos = RoundToGrid(tile.position);
            int x = (int)pos.x;
            int y = (int)pos.y;

            grid[x, y] = tile; // 블록 조각을 그리드에 기록
        }
    }
    void AddBlock(int pX, int pY)
    {

    }
}
