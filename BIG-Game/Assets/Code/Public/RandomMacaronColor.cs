using UnityEngine;

public class RandomMacaronColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void SetRandomMacaronColor()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            // 马卡龙颜色的RGB值范围
            float r = Random.Range(0.6f, 1f);
            float g = Random.Range(0.6f, 1f);
            float b = Random.Range(0.6f, 1f);

            // 将马卡龙颜色赋值给精灵图组件
            spriteRenderer.color = new Color(r, g, b);
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }


}