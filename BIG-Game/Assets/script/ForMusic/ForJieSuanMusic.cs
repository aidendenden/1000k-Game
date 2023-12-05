//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ForJieSuanMusic : MonoBehaviour
{
    private PointManager pointManager;
    public UnityEngine.UI.Image myImage; // �洢Image���
    public Sprite[] mySprites; // �洢���п��ܵľ���ͼ
    public int Kind = 0;
   

    public void SetImage(int imageIndex) // ���ݱ���������ͼƬ��ѡȡһ����Ϊ������ʾ��ͼ��
    {
        if (imageIndex >= 0 && imageIndex < mySprites.Length)
        {
            myImage.sprite = mySprites[imageIndex]; // ����indexѡ���Ӧ�ľ���ͼ
        }
        else
        {
            Debug.LogError("Image index out of range"); // ���index������Χ�����������Ϣ
        }
    }

    private void Start()
    {
        
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();

        if (Kind ==0)
        {
            if (pointManager.MusicScore <= 30)
            {
                SetImage(0);
            }
            if (pointManager.MusicScore > 30)
            {
                SetImage(1);
            }
            if (pointManager.MusicScore > 100)
            {
                SetImage(2);
            }
        }

        if (Kind == 1)
        {
            if (pointManager.DaDiShuScore<= 15)
            {
                SetImage(0);
            }
            if (pointManager.DaDiShuScore > 15)
            {
                SetImage(1);
            }
            if (pointManager.DaDiShuScore > 40)
            {
                SetImage(2);
            }
        }

        if (Kind == 2)
        {
            if (pointManager.TouZiScore <= 3)
            {
                SetImage(0);
            }
            if (pointManager.TouZiScore > 3)
            {
                SetImage(1);
            }
            if (pointManager.TouZiScore > 8)
            {
                SetImage(2);
            }
        }

        if (Kind == 3)
        {
            if (pointManager.DanZhuScore <= 5)
            {
                SetImage(0);
            }
            if (pointManager.DanZhuScore > 5)
            {
                SetImage(1);
            }
            if (pointManager.DanZhuScore > 12)
            {
                SetImage(2);
            }
        }

    }

    
}
