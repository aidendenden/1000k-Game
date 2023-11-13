using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public GameObject objectToSpawn; // Ҫ���ɵ�����
    public float spawnInterval = 2f; // ����ʱ����
    private float timer;

    void Update()
    {
        // ���¼�ʱ��
        timer += Time.deltaTime;

        // �����ʱ����������ʱ����
        if (timer >= spawnInterval)
        {
            // ���ü�ʱ��
            timer = 0f;

            // ��������
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
