using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HItPoint : MonoBehaviour
{
    public float Point = 1;
    //public float value; // 用来控制y坐标上涨的数值
    public float maxY = 6f; // y坐标的上限
    public float valueMax = 10f; // 数值的上限
    private float startY = 0f; // 起始y坐标

    public void Poing()
    {
        Point++;
    }


    void Start()
    {
        // 保存起始y坐标
        startY = transform.position.y;
    }

    void Update()
    {
        // 根据数值计算y坐标
        float newY = Mathf.Clamp(Point, 0, valueMax) / valueMax * maxY + startY;

        // 更新物体的y坐标
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

