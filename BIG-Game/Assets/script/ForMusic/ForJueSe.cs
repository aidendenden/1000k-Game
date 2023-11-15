using UnityEngine;

public class ForJueSe : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float coldTime = 1f;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
        
    }

    private void Update()
    {
        if (coldTime > 0)
        {
            coldTime -= Time.deltaTime;
        }
        else
        {
            SetSpriteColor();
            coldTime = 1f;
        }
    }
    public void SetSpriteColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // ����Ϊ��ɫ��͸����Ϊ1
            coldTime = 1f;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }
    public void SetSpriteColorGood()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(0.5f, 1f, 0.5F,1f); // ����Ϊ��ɫ��͸����Ϊ1
            coldTime = 1f;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }

    public void SetSpriteColorBad()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(0.5f, 0.5f, 0.5F, 0.5f); // ����Ϊ��ɫ��͸����Ϊ1
            coldTime = 1f;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }
}