using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private float timeLeft;

    public float visibleTime;

    void Start()
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        GameEvents.current.onWrongDisplay += DisplayPanel;    // 事件注册
    }

    private void LateUpdate()
    {
        if (timeLeft <= 0)
        {
            HidePanel();
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    private void DisplayPanel()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        timeLeft = visibleTime;
    }

    private void HidePanel()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
