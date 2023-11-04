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
            // ������ɫ��RGBֵ��Χ
            float r = Random.Range(0.6f, 1f);
            float g = Random.Range(0.6f, 1f);
            float b = Random.Range(0.6f, 1f);

            // ��������ɫ��ֵ������ͼ���
            spriteRenderer.color = new Color(r, g, b);
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }


}