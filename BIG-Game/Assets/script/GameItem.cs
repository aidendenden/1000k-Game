using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameItem : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEventManager.Instance.Triggered("接触到了" ,other.transform,Vector2.one);
    }
    
}
