using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Grid<TGridObject>
{
    private int width;
    private int height;
    private int cellSize;
    private Vector2Int gridCenter;
    private TGridObject[,] gridArray;
    
    // 构造函数
    public Grid(int width, int height, int cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new TGridObject[width, height];
    }

    public TGridObject GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        
        return default;
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }

    public void SetCenter(int x, int y)
    {
        gridCenter = new Vector2Int(x/cellSize, y/cellSize);
        Debug.Log("地图中心设定为："+gridCenter.ToString());
    }
}
