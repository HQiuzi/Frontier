using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private Node _currentNode;
    public Text tipText;
    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        GameEvents.current.onOpenTipGUI += OpenTip;
    }

    private void OpenTip(int cost,Node node)
    {
        Debug.Log("开"+cost);
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        tipText.text = "开发该地块需要"+cost+"经济值，是否开发？";
        _currentNode = node;
    }

    public void UnlockNode()
    {
        Debug.Log("是");
        _currentNode.Unlock();
        HideTip();
    }
    public void HideTip()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
