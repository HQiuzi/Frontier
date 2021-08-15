using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainBuildings", menuName = "ScriptableObjects/Terrain Buildings", order = 3)]
public class TerrainBuildings : ScriptableObject
{
    public TerrainBuilding[] buildings;
    public int openCost;
    public int costRate;
}

[Serializable]
public class TerrainBuilding
{
    public String buildingName;
    public GameObject prefab;
    public bool special;
}
