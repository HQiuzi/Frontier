using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BuildingStates { WORKING,WAITING,DEAD }
public class BuildingController : MonoBehaviour
{
    public BuildingStates buildingStates;
    public float updateTime;

    protected BuildingStatus bs;
    protected float timeLeft;

    public Node currentNode;

    private float greenTimeLeft;

    //弹出金币
    public event Action<int> onCoinShow;
    public void CoinShow(int coin)
    {
        if (onCoinShow != null)
        {
            onCoinShow(coin);
        }
    }
    //添加碳值
    public event Action<int> onGreenAdd;
    public void GreenAdd(int green)
    {
        if (onGreenAdd != null)
        {
            onGreenAdd(green);
        }
    }

    //接收金币
    public event Action onCoinHide;
    public event Action onToWorking;
    public void CoinHide()
    {
        if (onCoinHide != null && onToWorking != null)
        {
            onCoinHide();
            onToWorking();
        }
    }

    protected void Start()
    {
        this.onToWorking += ToWorking;    // 事件注册

        init();
    }

    void Update()
    {
        SwitchStates();
    }

    protected void init()
    {

        buildingStates = BuildingStates.WORKING;
        bs = GetComponent<BuildingStatus>();
        updateTime = bs.BDUpdateTime;
        timeLeft = updateTime;
        greenTimeLeft = updateTime;
    }
    public void SwitchStates()
    {
        switch (buildingStates)
        {
            case BuildingStates.WORKING:
                //时间到了
                if (timeLeft <= 0)
                {
                    CoinShow(bs.BDCoin);
                    buildingStates = BuildingStates.WAITING;
                }
                else
                {
                    timeLeft -= Time.deltaTime;
                }
                break;
            case BuildingStates.WAITING:
                
                break;
            case BuildingStates.DEAD:
                //特殊土地，已经不能再使用，需要手动拆除。
                Renderer renderer = GetComponent<Renderer>();
                renderer.material.SetColor("_Color", Color.red);
                currentNode.canSpecial = false;
                break;
            default:
                break;
        }


        if (greenTimeLeft <= 0)
        {
            //GreenAdd(bs.BDGreen);
            GameManager.getGM.Green += bs.BDGreen;
            greenTimeLeft = updateTime;
        }
        else
        {
            greenTimeLeft -= Time.deltaTime;
        }
    }

    public void ToWorking()
    {
        Debug.Log("父");
        bs.GetCoin();
        buildingStates = BuildingStates.WORKING;
        timeLeft = updateTime;
    }

}
