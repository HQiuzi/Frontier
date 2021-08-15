using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public bool unlocked = false;
    public bool isCenter = false;
    public bool canSpecial = true;

    public TerrainBuildings buildings;      // 存储地块可以建造的建筑物信息（Scriptable Object）

    private float _buildOffsetY = 2.0f;     // 建造物上下偏移
    private GameObject _currentBuilding;    // 当前的建造物（子物体）
    private int _currentBuildingIndex;   // 当前建造物在可建造建筑物中（buildings）的索引位置
    
    private int _x, _z; // 世界坐标

    Shader _shader;
    Renderer _renderer;
    Color _color;

    private void Start()
    {
        _x = (int) transform.position.x;
        _z = (int) transform.position.z;
        // 在网格地图中加入当前位置的地块（索引）
        AddNodeToGrid();

        if (unlocked)
        {
            Appear();
            if (isCenter)
            {
                // 如果该地块是地图中心，设定grid地图的中心位置坐标
                LandManager.current.SetLandCenter(_x, _z);
            }
        }
        _renderer = GetComponent<Renderer>();
        _shader = GetComponent<Renderer>().material.shader;
    }

    public bool Build(TerrainBuilding building)
    {
        if (_currentBuilding != null)
        {
            GameEvents.current.GameMessage("此处已经有建筑物！无法建造");
            return false;
        }
        GameObject preBuilding = building.prefab;
        BuildingStatus bs = preBuilding.GetComponent<BuildingStatus>();
        if (bs.CanBuy())
        {
            _currentBuilding = Instantiate(preBuilding, transform, false);
            _currentBuilding.transform.position += new Vector3(0, _buildOffsetY, 0);    // 调整位置保证不穿模
            _currentBuildingIndex = Array.IndexOf(buildings.buildings, building);

            Vector2Int gridPos = LandManager.current.ConvertWorldPosToGridPos(_x, _z);
            _currentBuilding.GetComponent<BuildingController>().currentNode = LandManager.current.GetNode(gridPos.x, gridPos.y);
            return true;
        }
        return false;
    }

    public bool DestroyBuilding()
    {
        if (_currentBuilding)
        {
            _currentBuilding.GetComponent<BuildingStatus>().DestroyMe();
            Destroy(_currentBuilding);
            _currentBuildingIndex = -1;
            return true;
        }

        return false;
    }

    public GameObject GetCurrentBuilding()
    {
        return _currentBuilding;
    }
    public TerrainBuilding GetTerrainBuilding()
    {
        TerrainBuilding building = buildings.buildings[_currentBuildingIndex];
        return building;
    }

    public String GetCurrentBuildingInfo()
    {
        String buildingName = buildings.buildings[_currentBuildingIndex].buildingName;
        return buildingName;
    }
    //void OnMouseEnter()
    //{
    //    _color = _renderer.material.GetColor("_Color");
    //    _renderer.material.shader = Shader.Find("Shine");
    //    _renderer.material.SetFloat("_RimIntensity", 4.0f);
    //}
    void OnMouseDown()
    {
        //_renderer.material.shader = Shader.Find("Shine");
        //_renderer.material.SetColor("_Color", _color);
        //_renderer.material.SetFloat("_RimIntensity", 10.0f);

        if (EventSystem.current.IsPointerOverGameObject())
        {
            // 如果鼠标点击位置有可交互UI
            return;
        }
        
        if (!unlocked)
        {
            //Unlock();
            int cost = buildings.openCost + buildings.costRate * (LandManager.current.ConvertWorldPosToGridPos(_x, _z) - LandManager.current.center).sqrMagnitude;
            GameEvents.current.OpenTipGUI(cost,this);
            GameEvents.current.CloseBuildGUI();
        }
        else
        {
            Vector2Int gridPos = LandManager.current.ConvertWorldPosToGridPos(_x, _z);

            GameEvents.current.OpenBuildGUI(gridPos.x, gridPos.y, buildings);
        }
    }


    //void OnMouseExit()
    //{
    //    _renderer.material.shader = _shader;
    //    _renderer.material.SetColor("_Color", _color);
    //    if (unlocked)
    //    {
    //        _renderer.material.SetColor("_Color", Color.white);
    //    }
        
    //}

    void Hide()
    {
        MeshRenderer[] meshes = transform.GetComponentsInChildren<MeshRenderer>();
        if (meshes != null)
        {
            foreach(MeshRenderer mesh in meshes)
            {
                mesh.enabled = false;
            }
        }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
    
    void Appear()
    {
        MeshRenderer[] meshes = transform.GetComponentsInChildren<MeshRenderer>();
        if (meshes != null)
        {
            foreach (MeshRenderer mesh in meshes)
            {
                mesh.enabled = true;
            }
        }
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.white);
    }
    
    public void Unlock()
    {

        //判断购买条件
        int cost=buildings.openCost+ buildings.costRate * (LandManager.current.ConvertWorldPosToGridPos(_x, _z)-LandManager.current.center).sqrMagnitude;
        if (GameManager.getGM.Coin < cost)//买不起
        {
            Debug.Log("金币不足！");
            GameEvents.current.WrongDisplay();
        }
        else
        {
            GameManager.getGM.Coin -= cost;
            GameEvents.current.CoinCountChange(-GameManager.getGM.Coin);

            unlocked = true;
            Appear();
            LandManager.current.LandNodeUnlock(_x, _z);
        }
        
    }
    
    void AddNodeToGrid()
    {
        // 在grid地图中加入该地块
        LandManager.current.SetGridValue(_x, _z, gameObject);
    }
}
