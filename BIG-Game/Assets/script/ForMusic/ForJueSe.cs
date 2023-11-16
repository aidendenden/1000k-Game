using UnityEngine;

public class ForJueSe : MonoBehaviour
{
    private Animator ani;
    private SpriteRenderer spriteRenderer;
    private float coldTime = 1f;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }

        ani = GetComponent<Animator>();
        if (ani == null)
        {
            Debug.LogWarning("ani component not found!");
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
            //SetBack();
            coldTime = 1f;
        }
    }
    public void SetSpriteColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // 设置为灰色，透明度为1
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
            spriteRenderer.color = new Color(0.5f, 1f, 0.5F,1f); // 设置为好色，透明度为1
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
            spriteRenderer.color = new Color(0.5f, 0.5f, 0.5F, 0.5f); // 设置为坏色，透明度为1
            coldTime = 1f;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }

    public void SetGood()
    {
        ani.SetTrigger("Good");
        coldTime = 1f;
    }

    public void SetBack()
    {
        ani.SetTrigger("Back");
        coldTime = 1f;
    }
}