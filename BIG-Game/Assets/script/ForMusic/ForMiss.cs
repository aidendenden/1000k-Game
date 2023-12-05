using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForMiss : MonoBehaviour
{
    public UnityEvent miss;
    public DingDong dingDong;
    private HPTiao hpTiao;

    private void Start()
    {
        hpTiao = GameObject.FindGameObjectWithTag("Hpaa").GetComponent<HPTiao>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            dingDong.PlayAudioThree();
            miss.Invoke();
            hpTiao.HpDown.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
