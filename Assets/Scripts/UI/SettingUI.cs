using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviour
{

    public BuildingData_SO[] buildings;
    public GameData_SO gameData;
    public TerrainBuildings[] terrainBuildings;



    public GameObject buildingPanel;
    public GameObject terrainPanel;
    public GameObject gamePanel;

    public int nowBuilding=0;
    public int nowTerrain = 0;

    private void Start()
    {
        init();
    }

    public void init()
    {
        buildingPanel.transform.Find("green").GetComponent<InputField>().text = buildings[nowBuilding].green.ToString();
        buildingPanel.transform.Find("coin").GetComponent<InputField>().text = buildings[nowBuilding].coin.ToString();
        buildingPanel.transform.Find("cost").GetComponent<InputField>().text = buildings[nowBuilding].costCoin.ToString();
        buildingPanel.transform.Find("time").GetComponent<InputField>().text = buildings[nowBuilding].updateTime.ToString();

        terrainPanel.transform.Find("costCoin").GetComponent<InputField>().text = terrainBuildings[nowTerrain].openCost.ToString();
        terrainPanel.transform.Find("costRate").GetComponent<InputField>().text = terrainBuildings[nowTerrain].costRate.ToString();

        gamePanel.transform.Find("green").GetComponent<InputField>().text = gameData.green.ToString();
        gamePanel.transform.Find("coin").GetComponent<InputField>().text = gameData.coin.ToString();
        gamePanel.transform.Find("greenRate").GetComponent<InputField>().text = gameData.greenRate.ToString();
        gamePanel.transform.Find("maxGreenRate").GetComponent<InputField>().text = gameData.maxGreenRate.ToString();
        gamePanel.transform.Find("minCoinRate").GetComponent<InputField>().text = gameData.minCoinRate.ToString();
    }

    public void changeBuilding(int num)
    {
        nowBuilding = num;
        init();
    }
    public void changeTerrain(int num)
    {
        nowTerrain = num;
        init();
    }


    #region setBuildings
    public void setBuildingGreen(string number)
    {
        buildings[nowBuilding].green = int.Parse(number);
    }

    public void setBuildingCoin(string number)
    {

        buildings[nowBuilding].coin = Convert.ToInt32(number);
    }

    public void setBuildingCost(string number)
    {
        
        buildings[nowBuilding].costCoin = Convert.ToInt32(number);
    }

    public void setBuildingTime(string number)
    {

        buildings[nowBuilding].updateTime = Convert.ToInt32(number);
    }

    #endregion

    #region setTerrain
    public void setTerrainCost(string number)
    {

        terrainBuildings[nowTerrain].openCost = Convert.ToInt32(number);
    }

    public void setTerrainRate(string number)
    {

        terrainBuildings[nowTerrain].costRate = Convert.ToInt32(number);
    }
    #endregion

    #region setGame
    public void setGameGreen(string number)
    {
        gameData.green = Convert.ToInt32(number);
    }
    public void setGameCoin(string number)
    {
        gameData.coin = Convert.ToInt32(number);
    }
    public void setGameGreenRate(string number)
    {
        gameData.greenRate = Convert.ToInt32(number);
    }
    public void setGameMaxGreenRate(string number)
    {
        gameData.maxGreenRate = Convert.ToInt32(number);
    }
    public void setGameMinCoinRate(string number)
    {
        gameData.minCoinRate = Convert.ToInt32(number);
    }
    #endregion

    public void Play()
    {
        SceneManager.LoadScene(0);
    }
}
