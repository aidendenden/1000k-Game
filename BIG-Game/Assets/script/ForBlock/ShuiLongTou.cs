using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuiLongTou : MonoBehaviour
{
    public GameObject objectToSpawn; // 要生成的游戏物体
    public float spawnInterval = 1.0f; // 生成间隔时间

    private float timer = 0.0f;

    void Update()
    {
        // 计时器递增
        timer += Time.deltaTime;

        // 检查是否到达生成间隔时间
        if (timer >= spawnInterval)
        {
            var b = new Vector3(Random.Range(-2,2), Random.Range(-2, 2),0);
            // 生成游戏物体
            Instantiate(objectToSpawn, transform.position+ b* Random.Range(1,2), Quaternion.identity);

            // 重置计时器
            timer = 0.0f;
        }
    }
}
