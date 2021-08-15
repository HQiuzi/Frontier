using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    static GameManager gm;

    public GameStatus gs;
    public GameObject resultPanel;

    [SerializeField]
    [Header("Game Status")]
    private int green;
    [SerializeField]
    private int coin;
    [SerializeField]
    private int greenRate;
    [SerializeField]
    private int coinRate;

    private int nodeCount;



    public static GameManager getGM
    {
        get
        {
            return gm;
        }
    }

    public int Green { get => green; set => green = value; }
    public int Coin { get => coin; set => coin = value; }
    public int GreenRate { get => greenRate; set => greenRate = value; }
    public int CoinRate { get => coinRate; set => coinRate = value; }

    public void checkGM()
    {
        if (gm == null)
        {
            gm = this;
        }else if (gm != null)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {

        GameEvents.current.onNodeUnlock += checkCount;
        GameEvents.current.onCoinRateCountChange += checkCoinRate;
        GameEvents.current.onGreenRateCountChange += checkCoinRate;
        
        checkGM();

    }

    void Start()
    {
        initGame();
    }

    public void initGame()
    {

        Debug.Log("Start awake");
        gs = GetComponent<GameStatus>();
        gm = this;

        Green = gs.Green;
        Coin = gs.Coin;
        GreenRate = gs.GreenRate;
        CoinRate = gs.CoinRate;

        GameEvents.current.CoinCountChange(-Coin);
        GameEvents.current.CoinRateCountChange(CoinRate);
        GameEvents.current.GreenRateCountChange(GreenRate);


    }

    public void checkCount(int x,int y,int count)
    {
        nodeCount = count;
        checkEnd();

    }
    public void checkCoinRate(int rate)
    {
        checkEnd();
    }
    private void checkEnd()
    {
        if (CoinRate <= 0 && Coin <= gs.MinCoin || GreenRate >= gs.MaxGreenRate)
        {
            resultPanel.SetActive(true);
            GameEvents.current.OpenResultGUI(0);
        }
        //全部解锁完成
        if (nodeCount == LandManager.current.size.x * LandManager.current.size.y)
        {
            if (CoinRate >= gs.MinCoinRate)
            {
                resultPanel.SetActive(true);
                GameEvents.current.OpenResultGUI(1);
            }

        }
    }

    public void GoSetting()
    {
        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        Application.Quit();
    }


}
