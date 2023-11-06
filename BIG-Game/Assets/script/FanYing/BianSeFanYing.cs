using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BianSeFanYing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
        else
        {
            //RandomizeSpriteColor();
        }
    }

    public void RandomizeSpriteColor()
    {
        if (spriteRenderer != null)
        {
            Color randomColor = new Color(Random.Range(0.1f, 0.8f), Random.Range(0.1f, 0.8f), Random.Range(0.1f, 0.8f));
            spriteRenderer.color = randomColor;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }
}
