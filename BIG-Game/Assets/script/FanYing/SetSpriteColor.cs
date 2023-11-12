using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetSpriteColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;



    private float TimeOne = 0.5f;
    


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
        animator = GetComponent<Animator>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning("animator component not found!");
        }
        else
        {
            SetSpriteToG();
        }
    }


    private void Update()
    {

        if (TimeOne > 0)
        {
            TimeOne -= Time.deltaTime;
        }
        else
        {
            TimeOne = 0.5f;
            //SetSpriteToG();

        }



       
    }

    public void Highlighter()
    {
        TimeOne = 0.5f;
        animator.SetTrigger("Jump");
        //SetSpriteToWhite();
    }

    

    public void SetSpriteToWhite()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // 设置为白色，透明度为1
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }

    public void SetSpriteToG()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 0.5f); // 设置为白色，透明度为1
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }
}
