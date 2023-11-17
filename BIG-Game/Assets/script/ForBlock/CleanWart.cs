using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanWart : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WW")
        {
            Destroy(collision.gameObject);
        }
    }
}
