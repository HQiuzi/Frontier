using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    // 单例
    public static LandManager current;
    
    public Vector2Int size;
    public int cellSize;
    public Vector2Int center;

    private Grid<GameObject> _grid;
    private int _buildingCount; // 建筑物数量
    private int _landCount=1;
    
    private void Awake()
    {
        current = this;
        _grid = new Grid<GameObject>(size.x, size.y, cellSize);
        GameEvents.current.onNodeUnlock += EnableNeigbourNode;    // 事件注册
    }
    
    public Vector2Int ConvertWorldPosToGridPos(int x, int y)
    {
        // 转换为地图坐标
        int _x = x / cellSize;
        int _y = y / cellSize;
        return new Vector2Int(_x, _y);
    }

    void EnableLandNode(GameObject node)
    {
        node.GetComponent<MeshRenderer>().enabled = true;
        node.GetComponent<BoxCollider>().enabled = true;
    }
    
    public void SetLandCenter(int x, int y)
    {
        Vector2Int gridPos = ConvertWorldPosToGridPos(x, y);
        center=gridPos;
        _grid.SetCenter(gridPos.x, gridPos.y);
        
    }

    public void SetGridValue(int x, int y, GameObject value)
    {
        Vector2Int gridPos = ConvertWorldPosToGridPos(x, y);
        _grid.SetValue(gridPos.x, gridPos.y, value);
    }
    
    // 在解锁某地块后，让其坐标周围的地块可以被解锁
    public void EnableNeigbourNode(int x, int y,int count)
    {   
        // 前后左右方向
        int[][] dirs = new int[4][]
        {
            new int[2] {-1,0},
            new int[2] {1, 0},
            new int[2] {0,-1},
            new int[2] {0, 1}
        };

        foreach (int[] dir in dirs)
        {
            int x_offset = dir[0];
            int y_offset = dir[1];
            GameObject neigbour = _grid.GetValue(x + x_offset, y + y_offset);
            if (neigbour != null)
            {
                EnableLandNode(neigbour);
            }
        }

    }
    
    public void LandNodeUnlock(int x, int y)
    {
        _landCount++;
        Vector2Int gridPos = ConvertWorldPosToGridPos(x, y);
        // 执行事件
        GameEvents.current.NodeUnlock(gridPos.x, gridPos.y,_landCount);
    }

    public void BuildOnNode(int x, int y, TerrainBuilding building)
    {
        Node node = _grid.GetValue(x, y).GetComponent<Node>();
        bool success = node.Build(building);
        if (success)
        {
            _buildingCount++;
            GameEvents.current.BuildCountChange(_buildingCount);
        }
    }

    public GameObject GetBuildingOnNode(int x, int y)
    {
        Node node = _grid.GetValue(x, y).GetComponent<Node>();
        GameObject currentBuilding = node.GetCurrentBuilding();
        if (currentBuilding != null)
        {
            return currentBuilding;
        }
        return null; // null
    }

    public String GetBuildingInfoOnNode(int x, int y)
    {
        Node node = _grid.GetValue(x, y).GetComponent<Node>();
        return node.GetCurrentBuildingInfo();
    }

    public void DestoryBuildingOnNode(int x, int y)
    {
        Node node = _grid.GetValue(x, y).GetComponent<Node>();
        bool success = node.DestroyBuilding();
        if (success)
        {
            _buildingCount--;
            GameEvents.current.BuildCountChange(_buildingCount);
        }
    }

    public TerrainBuilding GetBuildingByXY(int x,int y)
    {
        Node node = _grid.GetValue(x, y).GetComponent<Node>();
        return node.GetTerrainBuilding();
    }
    public Node GetNode(int x,int y)
    {
        Node node = _grid.GetValue(x, y).GetComponent<Node>();
        return node;
    }
}
