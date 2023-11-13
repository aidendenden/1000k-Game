using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System.IO;

[Serializable]
public class DiceImage
{
    public SpriteRenderer Answer;
    public int AnswerNum;
}

public class CountDownSystem : MonoBehaviour
{
    public CircularTimer[] circularTimers;
    

    //[Header("间隔时间")] public float WaitTime = 1f;

   // private WaitForSeconds waitTime;
    

    private void Awake()
    {
        //waitTime = new WaitForSeconds(WaitTime); 
    }

    private void Start()
    {
        if (circularTimers!=null||circularTimers.Length>0)
        {
            foreach (var VARIABLE in circularTimers)
            {
                VARIABLE.StartTimer();
            }
        }
      

       // StartCoroutine(EnumeratorGameStart());
    }

    

    // private IEnumerator EnumeratorGameStart()
    // {
    //     while (true)
    //     {
    //         // 调用您希望在每个时间间隔后执行的方法
    //         int index = 0;
    //         foreach (CircleTimerSprite timer in circularTimers)
    //         {
    //             int _int = UnityEngine.Random.Range(1, 2);
    //             if (_int==1)
    //             {
    //                 var _ = UnityEngine.Random.Range(2, 12);
    //                 Debug.Log(_+"目标数");
    //                 DiceImages[index].AnswerNum=_;
    //                 DiceImages[index].Answer.sprite = newSprite[_];
    //                 timer.StartTimer(); 
    //             }
    //             index++;
    //         }
    //
    //         yield return waitTime;
    //     }
    // }

    public void StartTimer()
    {
        foreach (var timer in circularTimers)
        {
            timer.StartTimer();
        }
    }

    public void PauseTimer()
    {
        foreach (var timer in circularTimers)
        {
            timer.PauseTimer();
        }
    }

    public void StopTimer()
    {
        foreach (var timer in circularTimers)
        {
            timer.StopTimer();
        }
    }

    public void ReStart()
    {
        foreach (var timer in circularTimers)
        {
            timer.StopTimer();
            timer.StartTimer();
        }
    }
}

    