using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 该脚本挂载在有TMP对象的物体上
// 用于显示游戏事件（文本提示）
public class GameEventDisplay : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    
    private void Start()
    {
        _textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        // 添加事件响应
        GameEvents.current.onNodeUnlock += DisplayNodeUnlockInfo;   
        GameEvents.current.onGameMessage += DisplayMessage;
    }

    private void DisplayNodeUnlockInfo(int x, int y,int count)
    {
        String str = String.Format("({0},{1}) 地块已解锁,共{2}块", x, y,count);
        _textMeshProUGUI.SetText(str);
    }

    private void DisplayMessage(String message)
    {
        _textMeshProUGUI.SetText(message);
    }
}
