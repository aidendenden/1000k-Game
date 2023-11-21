using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseHitt : MonoBehaviour
{
    public UnityEvent beShot;
    public UnityEvent beHit;
    public float shushuHP = 3;
    public HPTiao hPTiao;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TouchPoint")
        {
           if(shushuHP > 0)
            {
                shushuHP--;
                beShot.Invoke();
            }
            else
            {
                beHit.Invoke();
            }
            
        }
    }
}
