using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//IPointerEnterHandler, IPointerExitHandler
using UnityEngine.UI;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panel;
    private string _text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_text != null && _text!="")
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<Text>().text = _text;
        }
        

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        panel.SetActive(false);
    }

    public void getInfo(string info)
    {
        _text = info;
    }
}

