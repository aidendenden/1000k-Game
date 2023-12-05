using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustPuFadew : MonoBehaviour
{
    public Animator ani;


    public void Fadeoutt()
    {

        ani.SetTrigger("Out");
    }
}
