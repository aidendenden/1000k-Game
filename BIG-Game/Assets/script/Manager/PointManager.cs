using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private static PointManager instance;

    // 在这里定义你想要存储的变量，例如积分
    public int GameDianJi = 0;
    public int DianJi = 0;
    public float GameTime = 0;

    public string GameKind;

    public int TouZiScore = 0;
    

    public int DaDiShuScore = 0;
    public int DaDiShuShuLiang = 0;

    public int MusicScore = 0;
    public int MusicCombo = 0;
    public int maxCombo = 0;

    public int DanZhuScore = 0;




    public static PointManager Instance
    {
        get
        {
            if (instance == null)
            {
                // 如果实例不存在，尝试找到现有的实例
                instance = FindObjectOfType<PointManager>();

                // 如果没有找到现有实例，创建一个新的实例
                if (instance == null)
                {
                    GameObject singleton = new GameObject("PointManager");
                    instance = singleton.AddComponent<PointManager>();
                }
            }
            return instance;
        }
    }

    // 你的其他游戏逻辑可以在这里

    public void ZeroMusicPoint()
    {
        MusicCombo = 0;
        MusicScore = 0;
        maxCombo = 0;

    }
    public void addMusicPoint()
    {
        MusicScore++;
    }

    public void addMusicCombo()
    {
        MusicCombo++;
        if (MusicCombo >= maxCombo) {

            maxCombo = MusicCombo;
        }
    }

    public void ZeroMusicCombo()
    {
        MusicCombo = 0;
        
    }
    public void addDaDiShuScore(int points)
    {
        DaDiShuScore += points;
        
    }
    public void addDianJi()
    {
        GameDianJi++;
        DianJi++;

    }
    public void addTime(float b)
    {
        GameTime += b;

    }
    public void addDaDiShuLiang()
    {

        DaDiShuShuLiang++;
    }

    public void addDanZhuScore()
    {

        DanZhuScore++;
    }


    public void addTouziScore()
    {

        TouZiScore++;
    }


    public void TouZiZero()
    {
        TouZiScore = 0;
        GameDianJi = 0;
        GameTime = 0;
        
    }

    public void DanZhuZero()
    {
        DanZhuScore = 0;
        GameDianJi = 0;
        GameTime = 0;

    }
    public void DaDiShuZero()
    {
    DaDiShuScore = 0;
    GameDianJi  = 0;
    GameTime = 0;
    DaDiShuShuLiang = 0;
    }


    // 你可以在其他方法中添加更多的功能

    private void Awake()
    {
        // 确保只有一个实例存在，如果有多个则销毁多余的实例
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
