using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForMiss : MonoBehaviour
{
    public UnityEvent miss;
    public DingDong dingDong;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            dingDong.PlayAudioThree();
            miss.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
