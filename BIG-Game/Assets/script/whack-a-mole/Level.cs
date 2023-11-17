using UnityEngine;
using System;


/// <summary>
/// 此脚本定义游戏中的一个关卡。当玩家达到一定分数时，等级会提高，难度也会相应改变
/// </summary>
[Serializable]
public class Level
{
    [Tooltip("The score needed to win this level")]
    public int scoreToNextLevel = 200;

    [Tooltip("The time bonus for finishing this level")]
    public float timeBonus = 5;

    [Tooltip("The maximum number of targets allowed on screen at once")]
    public int maximumTargets = 2;
}