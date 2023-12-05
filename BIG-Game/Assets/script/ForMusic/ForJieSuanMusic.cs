//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ForJieSuanMusic : MonoBehaviour
{
    private PointManager pointManager;
    public UnityEngine.UI.Image myImage; // 存储Image组件
    public Sprite[] mySprites; // 存储所有可能的精灵图
    public int Kind = 0;
   

    public void SetImage(int imageIndex) // 根据变量从三张图片中选取一个作为物体显示的图像
    {
        if (imageIndex >= 0 && imageIndex < mySprites.Length)
        {
            myImage.sprite = mySprites[imageIndex]; // 根据index选择对应的精灵图
        }
        else
        {
            Debug.LogError("Image index out of range"); // 如果index超出范围，输出错误信息
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
