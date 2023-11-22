using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ParentSwitcher : MonoBehaviour
{

    public bool isWillDis = false;
    public bool onMove;
    public UnityEvent TouChi;
    public bool isDrop = false;
    public float Zhong = 3;

    private float disTime = 5;
    private Animator anim;
    private GameObject KuangZi;
    private HItPoint hItPoint;
    private bool isPass = false;
    private HPTiao hPTiao;
    private bool iscanBeTouch = true;
    private PointManager pointManager;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        KuangZi = GameObject.FindGameObjectWithTag("Kuang");
        hItPoint = GameObject.FindGameObjectWithTag("JinDu").GetComponent<HItPoint>();
        hPTiao = GameObject.FindGameObjectWithTag("Hpaa").GetComponent<HPTiao>();
        pointManager = GameObject.FindGameObjectWithTag("PointManager").GetComponent<PointManager>();
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

    public void HPdownn()
    {
        hPTiao.HpDown.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)                                                            
    {
        if (collision.gameObject.tag == "TouchPoint" && isDrop&& iscanBeTouch)
        {
            if (Zhong <=0)
            {
                TouChi.Invoke();
                iscanBeTouch = false;
            }
            else
            {
                Zhong--;
            }
            
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

        if (isDrop&&isWillDis)
        {
            if(disTime < 0)
            {
                anim.SetTrigger("End");
                disTime = 5f;
            }
            else
            {
                disTime -= Time.deltaTime;
            }
        }
    }
    public void MoveTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, KuangZi.transform.position, Time.deltaTime * 10f);
    }

    public void getPoint()
    {
        if(isPass == false)
        {
            hItPoint.Poing();
            pointManager.addDaDiShuLiang();
            pointManager.addDaDiShuScore(1);
            isPass = true;
        }
        
    }

    public void LosePoint()
    {
        if (isPass == false)
        {
            if (pointManager.DaDiShuScore >=1)
            {
                hItPoint.DePoing(1);
                pointManager.addDaDiShuScore(-1);
                isPass = true;
            }
            else
            {
                pointManager.DaDiShuScore = 0;
                hItPoint.DePoing(1);
                isPass = true;
            }
            
        }
        
    }
}
