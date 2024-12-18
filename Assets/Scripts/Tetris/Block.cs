using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private TetrisSetting SettingData;
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int width = 10;
    public static int height = 20;

    

    private static Transform[,] grid = new Transform[width, height];


    private void Update()
    {
        Move();
        Down();
    }

    private void Move()
    {

        if (Input.GetKeyDown(SettingData.keySetting.leftMoveKey))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!VaildMove())
                transform.position -= new Vector3(-1, 0, 0);
        }

        else if (Input.GetKeyDown(SettingData.keySetting.rightMoveKey))
        {
            transform.position += new Vector3(1, 0, 0);

            if (!VaildMove())
                transform.position -= new Vector3(1, 0, 0);
        }

        else if (Input.GetKeyDown(SettingData.keySetting.spinKey))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!VaildMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);

        }

    }

    private void Down()
    {
        fallTime = 1 - SettingData.MinoDropSpeed / 10;
        if (SettingData.IsMinoGravity)
        {

            if (Time.time - previousTime > (Input.GetKey(SettingData.keySetting.downKey) ? fallTime / 10 : fallTime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!VaildMove() && SettingData.IsFloor)
                {
                    transform.position -= new Vector3(0, -1, 0);
                    AddToGrid();
                    CheckForLine();
                    this.enabled = false;
                    Spawn.Instance.NewTetris();
                }
                previousTime = Time.time;
            }
        }
    }

    private void CheckForLine()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (Hasline(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    private bool Hasline(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null) return false;
        }
        return true;
    }

    private void DeleteLine(int i)
    {
        if(SettingData.MinoScore)
        Spawn.Instance.m_deleteLineNum++;

        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }


    private void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }
    private bool VaildMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null) return false;
        }

        return true;
    }
}
