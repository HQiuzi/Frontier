using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform coinPoint;
    public float visibleTime;
    public bool isVisible=true;

    private TextMeshProUGUI _textMeshProUGUI;
    private float timeLeft;

    Transform coinUI;
    Transform cam;
    BuildingController currentController;

    private void Start()
    {
        currentController = GetComponent<BuildingController>();
        currentController.onCoinShow += ShowCoin;    // 事件注册
        currentController.onCoinHide += HideCoin;    // 事件注册
        coinPoint = transform.Find("CoinPoint");
    }

    void OnEnable()
    {
        cam = Camera.main.transform;
        foreach(Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if(canvas.renderMode == RenderMode.WorldSpace)
            {
                coinUI = Instantiate(coinPrefab, canvas.transform).transform;
                coinUI.gameObject.SetActive(false);
                _textMeshProUGUI = coinUI.transform.Find("Text").GetComponent<TextMeshProUGUI>();

            }
        }
    }
    private void ShowCoin(int coin)
    {
        Debug.Log("收入：" + coin);
        if (coin != null && coin>0)
        {
            coinUI.gameObject.SetActive(true);
            _textMeshProUGUI.text="+"+coin;
            timeLeft = visibleTime;
        }
        else
        {
            Destroy(coinUI.gameObject);
        }
    }
    private void HideCoin()
    {
        coinUI.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (coinUI != null)
        {
            coinUI.position = coinPoint.position;
            coinUI.forward = cam.forward;

            if (!isVisible)
            {
                if (timeLeft <= 0)
                {
                    HideCoin();
                }
                else
                {
                    timeLeft -= Time.deltaTime;
                }
            }
            
        }
    }

}
