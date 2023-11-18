using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ParentSwitcher : MonoBehaviour
{
    public bool onMove;
    public UnityEvent TouChi;
    public bool isDrop = false;
    private Animator anim;
    private GameObject KuangZi;
    private HItPoint hItPoint;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        KuangZi = GameObject.FindGameObjectWithTag("Kuang");
        hItPoint = GameObject.FindGameObjectWithTag("JinDu").GetComponent<HItPoint>();
    }
    public void SwitchParent()
    {
        if(isDrop == false)
        {
            gameObject.transform.SetParent(null);
            anim.SetTrigger("Free");
            isDrop = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TouchPoint" && isDrop)
        {
            TouChi.Invoke();
        }
    }
 


    public void FadeOutFade() {

        onMove = true;
        anim.SetTrigger("FadeOut");
    }


    private void Update()
    {
        if (onMove)
        {
            MoveTo();
        }
    }
    public void MoveTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, KuangZi.transform.position, Time.deltaTime * 10f);
    }

    public void getPoint()
    {
        hItPoint.Poing();
    }
}
