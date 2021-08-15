using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="BuildingData",menuName= "ScriptableObjects/Building Status")]
public class BuildingData_SO : ScriptableObject
{
    [Header("Building Info")]
    public int green;
    public int coin;
    public int costCoin;
    public int updateTime;

    [Header("Other Info")]
    public string intro;

}
