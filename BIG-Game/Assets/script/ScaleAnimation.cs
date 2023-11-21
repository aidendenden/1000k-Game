using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    public float speed = 1f; // 缩放速度
    public float minScale = 0.5f; // 最小缩放比例
    public float maxScale = 1.5f; // 最大缩放比例

    private float time = 0f;

    private void Update()
    {
        // 基于时间计算缩放比例
        time += Time.deltaTime * speed;
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(time) + 1f) / 2f);

        // 应用缩放
        transform.localScale = new Vector3(scale, scale, scale);
    }
}