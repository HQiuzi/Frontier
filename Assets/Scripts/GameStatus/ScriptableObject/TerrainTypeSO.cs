using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainType", menuName = "ScriptableObjects/TerrainType", order = 2)]
public class TerrainType : ScriptableObject
{
   public string name;
   public GameObject prefab;
}
