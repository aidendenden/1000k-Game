using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPTiao : MonoBehaviour
{
    public GameObject[] Tiao;
    public FSMTouZi fsmTouZi;
    public int HpAA = 3;
    public int Kind = 0;
    public UnityEvent HpDown;
    public UnityEvent ZeroHp;

    void Update()
    {
        if (Kind == 0)
        {
            SetActiveObjects(Tiao, fsmTouZi.parameter.Hp);
        }
        if (Kind == 1)
        {
            SetActiveObjects(Tiao, HpAA);
        }

    }


    private void SetActiveObjects(GameObject[] objects, int count)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i < count)
            {
                objects[i].SetActive(true); // 将前count个物体设置为激活状态
            }
            else
            {
                objects[i].SetActive(false); // 将剩余的物体设置为关闭状态
            }
        }
    }

    public void HPdown(int a )
    {
        if (HpAA -a >= 0)
        {
            HpAA -= a;
        }
        else
        {
            HpAA = 0;
        }

        if (HpAA ==0)
        {
            ZeroHp.Invoke();
        }
    }


}
