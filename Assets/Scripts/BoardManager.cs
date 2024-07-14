using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is core of game
public class BoardManager : MonoBehaviour
{
    public GameManager Game;
    public int NumberOfRow;
    public int NumberOfCol;

    public GameObject SquarePrefab;
    public GameObject LinePrefab;

    void Start()
    {
        // Game is Parent of BoardManager
        Game = transform.parent.GetComponent<GameManager>();
        InitBoard();

    }

    void InitBoard()
    {
        var offsetY = -(NumberOfRow - 1) * 0.5f;
        var offsetX = -(NumberOfCol - 1) * 0.5f;
        for (var i = 0; i < NumberOfRow; i++)
        {
            for (var j = 0; j < NumberOfCol; j++)
            {
                var square = Instantiate(SquarePrefab,
                new Vector3(j + offsetX, i + offsetY, 0), Quaternion.identity);
                square.transform.parent = transform;
                square.name = "Square_" + i + "_" + j;
            }
        }
        for (var i = 0; i <= NumberOfRow; i++)
        {
            var line = Instantiate(LinePrefab,
            new Vector3(0, i + offsetY - 0.5f, 0), Quaternion.identity);
            line.transform.parent = transform;
            line.name = "Line_" + i;
            line.transform.localScale = new Vector3(NumberOfRow, 0.025f, 0);
        }

        for (var i = 0; i <= NumberOfCol; i++)
        {
            var line = Instantiate(LinePrefab,
            new Vector3(i + offsetX - 0.5f, 0, 0), Quaternion.identity);
            line.transform.parent = transform;
            line.name = "Line_" + i;
            line.transform.localScale = new Vector3(0.025f, NumberOfCol, 0);
        }

    }

}
