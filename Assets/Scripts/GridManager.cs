using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Grid Variables
    [SerializeField] private int width;
    [SerializeField] private int height;

    private void Start()
    {
        GenerateGrid();
    }

    private void Update()
    {
        
    }

    private void GenerateGrid()
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {

            }
        }
    }
}
