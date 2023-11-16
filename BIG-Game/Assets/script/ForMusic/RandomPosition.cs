using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Vector3[] positions; // 存储四个位置坐标

    private void Start()
    {
      
        // 随机选择一个位置坐标
        int randomIndex = Random.Range(0, 12);
        Vector3 randomPosition = positions[randomIndex];

        // 将物体移动到随机选择的位置坐标
        transform.position = randomPosition;
    }
}