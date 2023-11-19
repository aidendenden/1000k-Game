using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Tooltip("升级到下一关所需的得分")] public int scoreToNextLevel = 200;

    [Tooltip("完成本关的时间奖励")] public float timeBonus = 5;

    [Tooltip("屏幕上同时允许出现的最大目标数量")] public int maximumTargets = 2;
}
