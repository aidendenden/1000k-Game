using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForANIshushu : MonoBehaviour
{
    private Animator ani;
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    public void hita()
    {
        ani.SetTrigger("Hit");
    }
}
