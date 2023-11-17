using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuiLongTou : MonoBehaviour
{
    public GameObject objectToSpawn; // Ҫ���ɵ���Ϸ����
    public float spawnInterval = 1.0f; // ���ɼ��ʱ��

    private float timer = 0.0f;

    void Update()
    {
        // ��ʱ������
        timer += Time.deltaTime;

        // ����Ƿ񵽴����ɼ��ʱ��
        if (timer >= spawnInterval)
        {
            var b = new Vector3(Random.Range(-2,2), Random.Range(-2, 2),0);
            // ������Ϸ����
            Instantiate(objectToSpawn, transform.position+ b* Random.Range(1,2), Quaternion.identity);

            // ���ü�ʱ��
            timer = 0.0f;
        }
    }
}
