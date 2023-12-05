using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForJiFenBan : MonoBehaviour
{
    public Sprite[] numberSprites; // 数字0至9的图片数组

    public SpriteRenderer spriteRenderer; // 游戏物体的SpriteRenderer组件
    public SpriteRenderer spriteRenderer2; // 游戏物体的SpriteRenderer组件
    public SpriteRenderer spriteRenderer3; // 游戏物体的SpriteRenderer组件
    private PointManager pointManager;
    public int kind = 0;

    private void Start()
    {
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
    }

    private void Update()
    {
        if (kind == 0)
        {
            DisplayNumber(pointManager.TouZiScore, 1);
            DisplayNumber(pointManager.TouZiScore, 10);
            DisplayNumber(pointManager.TouZiScore, 100);
        }
        if (kind == 1)
        {
            DisplayNumber(pointManager.MusicScore, 1);
            DisplayNumber(pointManager.MusicScore, 10);
            DisplayNumber(pointManager.MusicScore, 100);
        }
        if (kind == 2)
        {
            DisplayNumber(pointManager.DaDiShuScore, 1);
            DisplayNumber(pointManager.DaDiShuScore, 10);
            DisplayNumber(pointManager.DaDiShuScore, 100);
        }

    }
    public void DisplayNumber(int number,int W)
    {
        
        if (W==1)
        {
            spriteRenderer.sprite = numberSprites[DisplayDigit(number,W)]; // 根据接收到的数字变量显示对应的图片
        }
        if (W == 10)
        {
            spriteRenderer2.sprite = numberSprites[DisplayDigit(number, W)]; // 根据接收到的数字变量显示对应的图片
        }
        if (W == 100)
        {
            spriteRenderer3.sprite = numberSprites[DisplayDigit(number, W)]; // 根据接收到的数字变量显示对应的图片
        }

    }


    public int DisplayDigit(int number, int digitPlace)
    {
        if (digitPlace == 1)
        {
            int digit = number % 10; // 获取个位数
            //Debug.Log("个位数是：" + digit);
            return digit;
        }
        else if (digitPlace == 10)
        {
            int digit = (number / 10) % 10; // 获取十位数
           // Debug.Log("十位数是：" + digit);
            return digit;
        }
        else if (digitPlace == 100)
        {
            int digit = (number / 100) % 10; // 获取百位数
           // Debug.Log("百位数是：" + digit);
            return digit;
        }
        else
        {
           // Debug.LogError("Invalid digit place: " + digitPlace);
            return 0;
        }
    }
}
