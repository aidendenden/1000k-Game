using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchingTest : MonoBehaviour
{
    public float decreaseRate = 1f;
    public float HuaDongHard = 200;
    public UnityEvent JiHuo;
    public bool IsShot = false;
    public float variable = 1f;
    public TypingSpeedCalculator typingSpeedCalculator;
    public bool ForOne = false;

    private bool AtiveOpen = true;


    public void JiHuoShot()
    {
        JiHuo.Invoke();
    }

    public void JiHuoNotHuaDong()
    {
        if (typingSpeedCalculator.isLianXueIng == false)
        {
            JiHuoShot();
        }
    }

    public void ForOneOpen()
    {
        if (ForOne)
        {
            AtiveOpen = true;
        }
        
    }
    public void HuaDongAdd()
    {
        if (AtiveOpen)
        {
            variable++;
        }
        
    }
    public void HuaDongClean ()
    {
        variable = 0f;
    }
    private void Update()
    {
        if (IsShot == false)
        {
            variable -= decreaseRate * Time.deltaTime;
            variable = Mathf.Max(variable, 0f);

            if (variable >= HuaDongHard)
            {
                variable = 0f;
                JiHuo.Invoke();
                if (ForOne)
                {
                    AtiveOpen = false;
                }

            }


        }
    }
}
