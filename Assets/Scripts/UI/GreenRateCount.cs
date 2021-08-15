using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GreenRateCount : MonoBehaviour
{

    private TextMeshProUGUI _textMeshProUGUI;

    // Start is called before the first frame update
    void Awake()
    {
        _textMeshProUGUI = transform.GetComponentsInChildren<TextMeshProUGUI>()[0];

        // 添加事件响应
        GameEvents.current.onGreenRateCountChange += ChangeGreenRateCount;
    }

    private void ChangeGreenRateCount(int greenRate)
    {
        int allGreenRate = GameManager.getGM.GreenRate;
        String str = String.Format("碳速率："+ allGreenRate + "/" + GameManager.getGM.gs.MaxGreenRate);
     

        _textMeshProUGUI.SetText(str);
    }
}
