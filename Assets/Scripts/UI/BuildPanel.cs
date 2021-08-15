using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildPanel : MonoBehaviour
{
    public GameObject titlePrefab;
    public GameObject buttonPrefab;
    private CanvasGroup _canvasGroup;
    private void Start()
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        GameEvents.current.onOpenBuildGUI += DisplayBuildPanel;
        GameEvents.current.onCloseBuildGUI += HideBuildPanel;
    }

    private void ShowPanel(int x,int y)
    {
        // 显示
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        // 清除当前内容
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // 显示当前选择位置
        String locInfo = String.Format("当前位置：({0}，{1}) ,{2}", x, y, LandManager.current.GetNode(x, y).canSpecial);
        GameObject posTitle = Instantiate(titlePrefab);
        posTitle.transform.SetParent(gameObject.transform, false);
        posTitle.GetComponent<TextMeshProUGUI>().SetText(locInfo);

        
    }

    private void DisplayBuildPanel(int x, int y, TerrainBuildings terrainBuildings)
    {
        
        
        
        
        
        
        // 显示当前的建筑物（如果有）
        // 并创建拆除按钮
        GameObject currentBuilding = LandManager.current.GetBuildingOnNode(x, y);
        if (currentBuilding)
        {
            String curBuildName = LandManager.current.GetBuildingInfoOnNode(x, y);
            String curBuildInfo = String.Format("当前建造物：{0} ", curBuildName);

            //收金币
            if (currentBuilding.GetComponent<BuildingController>().buildingStates == BuildingStates.WAITING)
            {

                currentBuilding.GetComponent<BuildingController>().CoinHide();
                // 不显示面板
                _canvasGroup.alpha = 0;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            }
            else
            {
                ShowPanel(x,y);

                GameObject buildTitle = Instantiate(titlePrefab);
                buildTitle.transform.SetParent(gameObject.transform, false);
                buildTitle.GetComponent<TextMeshProUGUI>().SetText(curBuildInfo);

                // 拆除按钮
                GameObject destoryButton = Instantiate(buttonPrefab) as GameObject;
                RectTransform rt = destoryButton.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, 40);
                destoryButton.transform.SetParent(gameObject.transform, false);
                // 设置按钮文字
                destoryButton.GetComponentInChildren<TextMeshProUGUI>().text = "拆除建筑";
                // 设置按钮点击事件
                Button btn = destoryButton.GetComponent<Button>();
                btn.onClick.AddListener(() => LandManager.current.DestoryBuildingOnNode(x, y));
                btn.onClick.AddListener(() => HideBuildPanel());
                btn.onClick.AddListener(() => DestroyUI(buildTitle));
                btn.onClick.AddListener(() => DestroyUI(destoryButton));
                
            }

            

            return; // 不显示下面的按钮
        }


        ShowPanel(x,y);

        // 创建按钮
        foreach (TerrainBuilding building in terrainBuildings.buildings)
        {
            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.transform.SetParent(gameObject.transform, false);
            // 设置按钮文字
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = String.Format(building.buildingName+"(￥"+building.prefab.GetComponent<BuildingStatus>().BDCostCoin+")");
            // 设置按钮点击事件
            newButton.GetComponent<ToolTip>().getInfo(building.prefab.GetComponent<BuildingStatus>().BDIntro);
            Button btn = newButton.GetComponent<Button>();
            btn.interactable = !(building.special&&!LandManager.current.GetNode(x,y).canSpecial);
            btn.onClick.AddListener(() => LandManager.current.BuildOnNode(x,y,building));
            btn.onClick.AddListener(() => DisplayBuildPanel(x,y,terrainBuildings)); // 刷新面板
        }
    }

    private void HideBuildPanel()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void DestroyUI(GameObject uiGameObject)
    {
        Destroy(uiGameObject);
    }
}
