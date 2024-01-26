using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCursor : MonoBehaviour
{
    public int x = 0;
    public int y = 0;
    [SerializeField] int MaxX = 10;
    [SerializeField] int MaxY = 10;
    [SerializeField] int MinX = 0;
    [SerializeField] int MinY = 0;
    public Lifegame lifegame;
    int timer = 0;
    [SerializeField] int timerMax = 10;
    [SerializeField] int direction = 0;
    void Start()
    {

        transform.position = new Vector3(x * lifegame.cellSize, y * lifegame.cellSize, 0);
        if (MinX < 0)
        {
            MinX = 0;
        }
        if (MinY < 0)
        {
            MinY = 0;
        }
        if (MaxX >= lifegame.width)
        {
            MaxX = lifegame.width - 1;
        }
        if (MaxY >= lifegame.height)
        {
            MaxY = lifegame.height - 1;
        }
        x = MaxX;
        y = MaxY;
    }
    void Update()
    {
        timer++;

        //îÕàÕì‡Çé©ìÆÇ≈âùïúÇ∑ÇÈ
        if(x == MaxX && y!=MaxY)
        {
            y++;
        }
        if (x == MinX && y!=MinY)
        {
            y--;
        }
        if (y == MaxY && x!=MinX)
        {
            x--;
        }
        if (y == MinY && x!=MaxX)
        {
            x++;
        }

        if (x < MinX)
        {
            x = MinX;
        }
        if (y < MinY)
        {
            y = MinY;
        }
        if (x > MaxX)
        {
            x = MaxX;
        }
        if (y > MaxY)
        {
            y = MaxY;
        }


        if (timer >= timerMax)
        {
            timer = 0;
            lifegame.MakeGlider(x, y, direction);
        }
        transform.position = new Vector3(x * lifegame.cellSize, y * lifegame.cellSize, 0);
    }
}
