using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 *  对游戏事件统一管理
 *  Action 是对委托的一种封装，可以直接对Action进行+=和-=操作
 */

public class GameEvents : MonoBehaviour
{   
    // 单例
    public static GameEvents current;
    
    private void Awake()
    {
        current = this;
    }
    
    // 广播游戏消息（UI显示）
    public event Action<String> onGameMessage;
    public void GameMessage(String message)
    {
        if (onGameMessage != null)
        {
            onGameMessage(message);
        }    
    }
    
    // 解锁地块事件
    public event Action<int, int,int> onNodeUnlock;
    public void NodeUnlock(int x, int y,int count)
    {
        if (onNodeUnlock != null)
        {
            onNodeUnlock(x, y,count);
        }
    }
    
    // 弹出建造面板GUI
    public event Action<int, int, TerrainBuildings> onOpenBuildGUI;
    public void OpenBuildGUI(int x, int y, TerrainBuildings buildings)
    {
        if (onOpenBuildGUI != null)
        {
            onOpenBuildGUI(x, y, buildings);
        }
    }
    
    // 关闭建造面板GUI
    public event Action onCloseBuildGUI;
    public void CloseBuildGUI()
    {
        if (onCloseBuildGUI != null)
        {
            onCloseBuildGUI();
        }
    }
    //更改建造数量
    public event Action<int> onBuildCountChange;
    public void BuildCountChange(int count)
    {
        if (onBuildCountChange != null)
        {
            onBuildCountChange(count);
        }
    }

    // 弹出结果面板GUI
    public event Action<int> onOpenResultGUI;
    public void OpenResultGUI(int res)
    {
        if (onOpenResultGUI != null)
        {
            onOpenResultGUI(res);
        }
    }

    // 弹出提示面板GUI
    public event Action<int, Node> onOpenTipGUI;
    public void OpenTipGUI(int cost, Node node)
    {
        if (onOpenTipGUI != null)
        {
            onOpenTipGUI(cost, node);
        }
    }



    //错误提示
    public event Action onWrongDisplay;
    public void WrongDisplay()
    {
        if (onWrongDisplay != null)
        {
            onWrongDisplay();
        }
    }




    //更改金币总数
    public event Action<int> onCoinCountChange;
    public void CoinCountChange(int coin)
    {
        if (onCoinCountChange != null)
        {
            onCoinCountChange(coin);
        }
    }
    //更改繁荣度
    public event Action<int> onCoinRateCountChange;
    public void CoinRateCountChange(int coinRate)
    {
        if (onCoinRateCountChange != null)
        {
            onCoinRateCountChange(coinRate);
        }
    }

    //更改碳速率
    public event Action<int> onGreenRateCountChange;
    public void GreenRateCountChange(int greenRate)
    {
        if (onGreenRateCountChange != null)
        {
            onGreenRateCountChange(greenRate);
        }
    }

}
