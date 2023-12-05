using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteCon : MonoBehaviour
{
    private MusicPoint musicPoint;
    private Animator ani;

   


    
    public float speed = 5f;



    private void Start()
    {
        musicPoint = GameObject.FindGameObjectWithTag("PManager").GetComponent<MusicPoint>();
        ani = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChuFa")
        {
            ani.SetTrigger("OOUT");
        }
    }


    

    void Update()
    {
        
        transform.Translate(Vector3.down * (speed+musicPoint.point/80)* Time.deltaTime);
    }
}
