using UnityEngine;

public class SpawnNiuKou : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // 预制体数组

    void Start()
    {
        // 从预制体数组中随机选择一个预制体
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        GameObject selectedPrefab = prefabsToSpawn[randomIndex];

        // 实例化选择的预制体作为自己的子物体
        GameObject spawnedObject = Instantiate(selectedPrefab, new Vector3 (2,6,0), Quaternion.identity, transform);

    }
}