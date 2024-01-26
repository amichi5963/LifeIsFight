using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public int x = 0;
    public int y = 0;
    public Lifegame lifegame;
    [SerializeField] int direction = 1;
    void Start()
    {
        transform.position = new Vector3(x * lifegame.cellSize, y * lifegame.cellSize, 0);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x--;
        }
        if (x < 0)
        {
            x = 0;
        }
        if (y < 0)
        {
            y = 0;
        }
        if (x > lifegame.width)
        {
            x = lifegame.width;
        }
        if (y > lifegame.height)
        {
            y = lifegame.height;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lifegame.MakeGlider(x, y, direction);
        }
        transform.position = new Vector3(x * lifegame.cellSize, y * lifegame.cellSize, 0);
    }
}