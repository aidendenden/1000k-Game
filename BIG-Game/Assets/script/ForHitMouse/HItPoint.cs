using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HItPoint : MonoBehaviour
{
    public float Point = 1;
    //public float value; // ��������y�������ǵ���ֵ
    public float maxY = 6f; // y���������
    public float valueMax = 10f; // ��ֵ������
    private float startY = 0f; // ��ʼy����

    public void Poing()
    {
        Point++;
    }


    void Start()
    {
        // ������ʼy����
        startY = transform.position.y;
    }

    void Update()
    {
        // ������ֵ����y����
        float newY = Mathf.Clamp(Point, 0, valueMax) / valueMax * maxY + startY;

        // ���������y����
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

