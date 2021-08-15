using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildCount : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    
    private void Start()
    {
        _textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        // 添加事件响应
        GameEvents.current.onBuildCountChange += DisplayBuildCount;
    }

    private void DisplayBuildCount(int count)
    {
        String str = String.Format("建筑数量:{0}",count);
        _textMeshProUGUI.SetText(str);
    }
}
