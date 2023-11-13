using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public GameObject objectToSpawn; // 要生成的物体
    public float spawnInterval = 2f; // 生成时间间隔
    private float timer;

    void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 如果计时器超过生成时间间隔
        if (timer >= spawnInterval)
        {
            // 重置计时器
            timer = 0f;

            // 生成物体
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
