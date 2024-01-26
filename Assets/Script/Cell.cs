using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    bool isAlive = false;
    [SerializeField]SpriteRenderer spriteRenderer;
    void Start()
    {
    }
    public void SetAlive(bool alive)
    {
        isAlive = alive;
        spriteRenderer.color = isAlive ? Color.white : Color.black;
    }
}