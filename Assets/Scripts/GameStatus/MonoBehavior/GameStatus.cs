using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public GameData_SO gameData;

    #region Read from GameData_SO

    public int Green
    {
        get
        {
            if (gameData != null)
            {
                return gameData.green;
            }
            else return 0;
        }
        set
        {
            gameData.green = value;
        }
    }
    public int GreenRate
    {
        get
        {
            if (gameData != null)
            {
                return gameData.greenRate;
            }
            else return 0;
        }
        set
        {
            gameData.greenRate = value;
        }
    }
    public int Coin
    {
        get
        {
            Debug.Log(gameData);
            if (gameData != null)
            {

                return gameData.coin;
            }
            else return 0;
        }
        set
        {
            gameData.coin = value;
        }
    }
    public int CoinRate
    {
        get
        {
            if (gameData != null)
            {
                return gameData.coinRate;
            }
            else return 0;
        }
        set
        {
            gameData.coinRate = value;
        }
    }

    public int MinCoinRate {
        get
        {
            if (gameData != null)
            {
                return gameData.minCoinRate;
            }
            else return 0;
        }
        set
        {
            gameData.minCoinRate = value;
        }
    }
    public int MaxGreenRate {
        get
        {
            if (gameData != null)
            {
                return gameData.maxGreenRate;
            }
            else return 0;
        }
        set
        {
            gameData.maxGreenRate = value;
        }
    }

    public int MinCoin
    {
        get
        {
            if (gameData != null)
            {
                return gameData.minCoin;
            }
            else return 0;
        }
        set
        {
            gameData.minCoin = value;
        }
    }
    #endregion


}
