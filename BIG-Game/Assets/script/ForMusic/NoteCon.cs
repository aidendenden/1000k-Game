using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteCon : MonoBehaviour
{
    private MusicPoint musicPoint;


    
    public float speed = 5f;



    private void Start()
    {
        musicPoint = GameObject.FindGameObjectWithTag("PManager").GetComponent<MusicPoint>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChuFa")
        {
            Destroy(gameObject);
        }
    }


    

    void Update()
    {
        
        transform.Translate(Vector3.down * (speed+musicPoint.point/80)* Time.deltaTime);
    }
}
