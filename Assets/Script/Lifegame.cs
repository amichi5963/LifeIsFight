using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifegame : MonoBehaviour
{
   public int width = 10;
    public int height = 10;
    public float cellSize = 1.0f;
    public GameObject cellPrefab;
    public GameObject[,] cells;
    public int[,] board;
    public int[,] nextBoard;
    public int generation = 0;
    public float interval = 1.0f;
    private float timer = 0.0f;
    public bool isRunning = false;
    sbyte[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
    sbyte[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };
    void Start()
    {
        cells = new GameObject[width, height];
        board = new int[width, height];
        nextBoard = new int[width, height];
        for (int y = 0; y < height; y++)
        {
            float yPos = y * cellSize;
            for (int x = 0; x < width; x++)
            {
                float xPos = x * cellSize;
                GameObject cell = Instantiate(cellPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
                cell.transform.parent = transform;
                cells[x, y] = cell;
            }
        }
        cells[0, 0].GetComponent<Cell>().SetAlive(true);
        cells[1, 1].GetComponent<Cell>().SetAlive(true);
        cells[2, 1].GetComponent<Cell>().SetAlive(true);
        cells[0, 2].GetComponent<Cell>().SetAlive(true);
        cells[1, 2].GetComponent<Cell>().SetAlive(true);
        board[0, 0] = 1;
        board[1, 1] = 1;
        board[2, 1] = 1;
        board[0, 2] = 1;
        board[1, 2] = 1;
        isRunning = true;
    }
    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                timer = 0.0f;
                UpdateBoard();
                generation++;
            }
        }
    }
    public void MakeGlider(int x, int y,int direction)
    {


        if (direction == 0)
        {
            board[x, y] = 1;
            board[x + 1, y] = 1;
            board[x + 2, y] = 1;
            board[x, y + 1] = 1;
            board[x + 1, y + 2] = 1;
        }
        if (direction == 1)
        {
            board[x, y] = 1;
            board[x - 1, y] = 1;
            board[x - 2, y] = 1;
            board[x, y + 1] = 1;
            board[x - 1, y + 2] = 1;
        }
        if (direction == 2)
        {
            board[x, y] = 1;
            board[x, y - 1] = 1;
            board[x, y - 2] = 1;
            board[x + 1, y] = 1;
            board[x + 2, y - 1] = 1;
        }
        if (direction == 3)
        {
            board[x, y] = 1;
            board[x, y - 1] = 1;
            board[x, y - 2] = 1;
            board[x - 1, y] = 1;
            board[x - 2, y - 1] = 1;
        }
    }
    void UpdateBoard()
    {
        // 1. Count the number of neighbors
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int count = 0;
                for (int i = 0; i < 8; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx < 0) continue;
                    if (nx >= width) continue;
                    if (ny < 0) continue;
                    if (ny >= height) continue;
                    if (board[nx, ny] == 1) count++;
                }
                nextBoard[x, y] = board[x, y];
                if (board[x, y] == 1)
                {
                    if (count <= 1) nextBoard[x, y] = 0;
                    if (count >= 4) nextBoard[x, y] = 0;
                }
                else
                {
                    if (count == 3) nextBoard[x, y] = 1;
                }
            }
        }
        // 2. Update the board
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int xPos = x;
                if (x == 0) xPos = width - 1;
                if (x == width - 1) xPos = 0;
                board[x, y] = nextBoard[x, y];
                cells[x, y].GetComponent<Cell>().SetAlive(board[x, y] == 1);
            }
        }
    }
}