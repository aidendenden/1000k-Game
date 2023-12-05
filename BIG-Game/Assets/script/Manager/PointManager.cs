using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private static PointManager instance;

    // �����ﶨ������Ҫ�洢�ı������������
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
                // ���ʵ�������ڣ������ҵ����е�ʵ��
                instance = FindObjectOfType<PointManager>();

                // ���û���ҵ�����ʵ��������һ���µ�ʵ��
                if (instance == null)
                {
                    GameObject singleton = new GameObject("PointManager");
                    instance = singleton.AddComponent<PointManager>();
                }
            }
            return instance;
        }
    }

    // ���������Ϸ�߼�����������

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


    // �������������������Ӹ���Ĺ���

    private void Awake()
    {
        // ȷ��ֻ��һ��ʵ�����ڣ�����ж�������ٶ����ʵ��
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
