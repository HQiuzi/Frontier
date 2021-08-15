using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinRateCount : MonoBehaviour
{

    private TextMeshProUGUI _textMeshProUGUI;


    void Awake()
    {
        _textMeshProUGUI = transform.GetComponentsInChildren<TextMeshProUGUI>()[0];

        // 添加事件响应
        GameEvents.current.onCoinRateCountChange += ChangeCoinRateCount;
    }

    private void ChangeCoinRateCount(int coinRate)
    {
        int allCoinRate = GameManager.getGM.CoinRate;
        String str = String.Format("繁荣度："+allCoinRate+"/"+GameManager.getGM.gs.MinCoinRate);
        if (allCoinRate >= GameManager.getGM.gs.MinCoinRate)
        {
            str = String.Format(str+"√");
        }
        _textMeshProUGUI.SetText(str);
    }
}
