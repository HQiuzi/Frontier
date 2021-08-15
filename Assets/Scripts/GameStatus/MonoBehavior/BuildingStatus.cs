using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStatus : MonoBehaviour
{
    public BuildingData_SO buildingData;

    #region Read from BuildingData_SO
    public int BDGreen {
        get
        {
            if (buildingData != null)
            {
                return buildingData.green;
            }
            else return 0;
        }
        set
        {
            buildingData.green = value;
        }
    }


    public int BDCoin
    {
        get
        {
            if (buildingData != null)
            {
                return buildingData.coin;
            }
            else return 0;
        }
        set
        {
            buildingData.coin = value;
        }
    }

    public int BDCostCoin
    {
        get
        {
            if (buildingData != null)
            {
                return buildingData.costCoin;
            }
            else return 0;
        }
        set
        {
            buildingData.costCoin = value;
        }
    }


    public int BDUpdateTime
    {
        get
        {
            if (buildingData != null)
            {
                return buildingData.updateTime;
            }
            else return 0;
        }
        set
        {
            buildingData.updateTime = value;
        }
    }

    public string BDIntro
    {
        get
        {
            if (buildingData != null)
            {
                return buildingData.intro;
            }
            else return null;
        }
        set
        {
            buildingData.intro = value;
        }
    }
    #endregion


    public bool CanBuy()
    {
        Debug.Log("总数："+ GameManager.getGM.Coin);
        Debug.Log("需要：" + BDCostCoin);
        if (GameManager.getGM.Coin < BDCostCoin)
        {
            Debug.Log("金币不足！");
            GameEvents.current.WrongDisplay();
            return false;
        }
        else
        {
            GameManager.getGM.Coin -= BDCostCoin;
            GameEvents.current.CoinCountChange(-GameManager.getGM.Coin);

            GameManager.getGM.CoinRate += BDCoin;
            GameEvents.current.CoinRateCountChange(GameManager.getGM.CoinRate);

            GameManager.getGM.GreenRate += BDGreen;
            GameEvents.current.GreenRateCountChange(GameManager.getGM.GreenRate);
            return true;
        }
        
    }

    public void GetCoin()
    {
        GameManager.getGM.Coin += BDCoin;
        Debug.Log("收入2：" + BDCoin);
        GameEvents.current.CoinCountChange(GameManager.getGM.Coin);
    }

    public void DestroyMe()
    {
        Debug.Log("修改繁荣度：" + BDCoin);
        GameManager.getGM.CoinRate -= BDCoin;
        GameEvents.current.CoinRateCountChange(GameManager.getGM.CoinRate);

        GameManager.getGM.GreenRate -= BDGreen;
        GameEvents.current.GreenRateCountChange(GameManager.getGM.GreenRate);
    }
}
