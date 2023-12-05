using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForJiFenBan : MonoBehaviour
{
    public Sprite[] numberSprites; // ����0��9��ͼƬ����

    public SpriteRenderer spriteRenderer; // ��Ϸ�����SpriteRenderer���
    public SpriteRenderer spriteRenderer2; // ��Ϸ�����SpriteRenderer���
    public SpriteRenderer spriteRenderer3; // ��Ϸ�����SpriteRenderer���
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
            spriteRenderer.sprite = numberSprites[DisplayDigit(number,W)]; // ���ݽ��յ������ֱ�����ʾ��Ӧ��ͼƬ
        }
        if (W == 10)
        {
            spriteRenderer2.sprite = numberSprites[DisplayDigit(number, W)]; // ���ݽ��յ������ֱ�����ʾ��Ӧ��ͼƬ
        }
        if (W == 100)
        {
            spriteRenderer3.sprite = numberSprites[DisplayDigit(number, W)]; // ���ݽ��յ������ֱ�����ʾ��Ӧ��ͼƬ
        }

    }


    public int DisplayDigit(int number, int digitPlace)
    {
        if (digitPlace == 1)
        {
            int digit = number % 10; // ��ȡ��λ��
            //Debug.Log("��λ���ǣ�" + digit);
            return digit;
        }
        else if (digitPlace == 10)
        {
            int digit = (number / 10) % 10; // ��ȡʮλ��
           // Debug.Log("ʮλ���ǣ�" + digit);
            return digit;
        }
        else if (digitPlace == 100)
        {
            int digit = (number / 100) % 10; // ��ȡ��λ��
           // Debug.Log("��λ���ǣ�" + digit);
            return digit;
        }
        else
        {
           // Debug.LogError("Invalid digit place: " + digitPlace);
            return 0;
        }
    }
}
