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

    public GameObject BaoShu;
    public GameObject HaoShu1;
    public GameObject HaoShu2;
    public GameObject HaoShu3;
    public GameObject HaoShu4;
    public SpawnMouse spawnMouse1;
    public SpawnMouse spawnMouse2;

    public void Poing()
    {
        Point++;
        if(Point == 2)
        {
            spawnMouse1.prefabsToSpawn[0] = BaoShu;
            spawnMouse2.prefabsToSpawn[0] = BaoShu;
        }
        if (Point == 12)
        {
            spawnMouse1.prefabsToSpawn[1] = BaoShu;
            spawnMouse2.prefabsToSpawn[1] = BaoShu;
        }
        if (Point == 22)
        {
            spawnMouse1.prefabsToSpawn[2] = BaoShu;
            spawnMouse2.prefabsToSpawn[2] = BaoShu;

        }
        if (Point == 30)
        {
            spawnMouse1.prefabsToSpawn[3] = BaoShu;
            spawnMouse2.prefabsToSpawn[3] = BaoShu;
        }


    }

    public void DePoing(float a)
    {
        if (Point - a >= 0)
        {

            Point -= a;

            if (Point < 2)
            {
                spawnMouse1.prefabsToSpawn[0] = HaoShu1;
                spawnMouse2.prefabsToSpawn[0] = HaoShu1;
            }
            if (Point < 12)
            {
                spawnMouse1.prefabsToSpawn[1] = HaoShu2;
                spawnMouse2.prefabsToSpawn[1] = HaoShu2;
            }
            if (Point < 22)
            {
                spawnMouse1.prefabsToSpawn[2] =HaoShu3;
                spawnMouse2.prefabsToSpawn[2] = HaoShu3;
            }

            if (Point < 30)
            {
                spawnMouse1.prefabsToSpawn[3] = HaoShu4;
                spawnMouse2.prefabsToSpawn[3] = HaoShu4;
            }
        }
        else {

            Point = 0;

            spawnMouse1.prefabsToSpawn[0] = HaoShu1;
            spawnMouse2.prefabsToSpawn[0] = HaoShu1;
            spawnMouse1.prefabsToSpawn[1] = HaoShu2;
            spawnMouse2.prefabsToSpawn[1] = HaoShu2;
            spawnMouse1.prefabsToSpawn[2] = HaoShu3;
            spawnMouse2.prefabsToSpawn[2] = HaoShu3;
            spawnMouse1.prefabsToSpawn[3] = HaoShu4;
            spawnMouse2.prefabsToSpawn[3] = HaoShu4;
        
        
        }
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

