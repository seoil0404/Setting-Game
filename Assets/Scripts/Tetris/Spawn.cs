using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    [SerializeField] private TetrisSetting SettingData;

    public GameObject[] Tetris;
    public int m_deleteLineNum;
    public static Spawn Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NewTetris();
    }

    public void NewTetris()
    {
        if (SettingData.IsMinoRandom)
            Instantiate(Tetris[Random.Range(0, Tetris.Length)], transform.position, Quaternion.identity);
        else
            Instantiate(Tetris[0], transform.position, Quaternion.identity);
    }

    public void Restart()
    {
        SceneManager.LoadScene("TetrisScene");
    }
    // Update is called once per frame
    void Update()
    {

    }
}