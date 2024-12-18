using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Tetris;
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
        Instantiate(Tetris[Random.Range(0, Tetris.Length)], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}