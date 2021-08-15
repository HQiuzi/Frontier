using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameEvents.current.onOpenResultGUI += openResult;
    }
    private void openResult(int res)
    {
        
        if (res == 0)
        {
            _textMeshProUGUI.SetText("游戏失败");
        }
        else
        {
            _textMeshProUGUI.SetText("游戏通关");
        }
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
