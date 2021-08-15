using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLandController : BuildingController
{
    [SerializeField]
    private int count = 0;

    public int times = 10;

    protected new void Start()
    {
        this.onToWorking += ToWorking;    // 事件注册
        

        init();
    }

    public new void ToWorking()
    {
        Debug.Log("子");
        timeLeft = updateTime;
        bs.GetCoin();
        count++;

        if (count >= times)
        {
            buildingStates = BuildingStates.DEAD;
        }
        else
        {
            buildingStates = BuildingStates.WORKING;
        }
        
        
    }
}
