using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchingTest : MonoBehaviour
{
    public float decreaseRate = 1f;
    public float HuaDongHard = 200;
    public UnityEvent JiHuo;

    public float variable = 1f;
    

    public void HuaDongAdd()
    {
        variable++;
    }
    public void HuaDongClean ()
    {
        variable = 0f;
    }
    private void Update()
    {

        variable -= decreaseRate * Time.deltaTime;
        variable = Mathf.Max(variable, 0f);

        if(variable >= HuaDongHard)
        {
            variable = 0f;
            JiHuo.Invoke();
        }


    }
}
