using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCon : MonoBehaviour
{

    
    public float speed = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChuFa")
        {
            Destroy(gameObject);
        }
    }


    

    void Update()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
