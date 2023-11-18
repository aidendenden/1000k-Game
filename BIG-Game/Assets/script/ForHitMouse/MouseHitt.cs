using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseHitt : MonoBehaviour
{
    public UnityEvent beHit;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TouchPoint")
        {
            beHit.Invoke();
        }
    }
}
