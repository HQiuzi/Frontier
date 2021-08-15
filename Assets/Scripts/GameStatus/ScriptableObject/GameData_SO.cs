using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/Game Status")]
public class GameData_SO : ScriptableObject
{
    [Header("Game Status")]
    public int green;
    public int coin;
    public int greenRate;
    public int coinRate;

    [Header("Pass Check")]
    public int minCoinRate;
    public int maxGreenRate;

    [Header("Fail Check")]
    public int minCoin;
    public int maxGreen;

    
}
