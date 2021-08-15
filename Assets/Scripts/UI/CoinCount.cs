using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinCount : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;

    // Start is called before the first frame update
    void Awake()
    {
        _textMeshProUGUI = transform.GetComponentsInChildren<TextMeshProUGUI>()[0];

        // 添加事件响应
        GameEvents.current.onCoinCountChange += ChangeCoinCount;
    }

    private void ChangeCoinCount(int coin)
    {
        
        int allCoin = GameManager.getGM.Coin;
        String str = String.Format("经济值："+allCoin);
        _textMeshProUGUI.SetText(str);
        Debug.Log("剩余：" + allCoin);
    }
}
