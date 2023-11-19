using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMouse : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // 要生成的预制体数组
    public Transform spawnPosition; // 生成位置
    public float spawnInterval = 3f; // 生成间隔时间
    private float timer = 0f; // 计时器
    public HItPoint hitpoint;

    void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 如果计时器超过生成间隔时间
        if (timer >= spawnInterval- (hitpoint.Point/50f*spawnInterval*0.6))
        {
            // 重置计时器
            timer = 0f;

            // 从预制体数组中随机选择一个预制体
            GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

            // 生成随机选择的预制体在指定位置
            Instantiate(randomPrefab, spawnPosition.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        // 从预制体数组中随机选择一个预制体
        GameObject randomPrefab = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

        // 生成随机选择的预制体在指定位置
        Instantiate(randomPrefab, spawnPosition.position, Quaternion.identity);
    }
}
