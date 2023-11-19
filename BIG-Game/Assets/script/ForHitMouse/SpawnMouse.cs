using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMouse : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Ҫ���ɵ�Ԥ��������
    public Transform spawnPosition; // ����λ��
    public float spawnInterval = 3f; // ���ɼ��ʱ��
    private float timer = 0f; // ��ʱ��
    public HItPoint hitpoint;

    void Update()
    {
        // ���¼�ʱ��
        timer += Time.deltaTime;

        // �����ʱ���������ɼ��ʱ��
        if (timer >= spawnInterval- (hitpoint.Point/50f*spawnInterval*0.6))
        {
            // ���ü�ʱ��
            timer = 0f;

            // ��Ԥ�������������ѡ��һ��Ԥ����
            GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

            // �������ѡ���Ԥ������ָ��λ��
            Instantiate(randomPrefab, spawnPosition.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        // ��Ԥ�������������ѡ��һ��Ԥ����
        GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        // �������ѡ���Ԥ������ָ��λ��
        Instantiate(randomPrefab, spawnPosition.position, Quaternion.identity);
    }
}
