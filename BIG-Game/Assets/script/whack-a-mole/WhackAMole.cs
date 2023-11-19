using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WhackAMole : MonoBehaviour
{
    [Tooltip("快速出现的鼹鼠的概率。这会覆盖戴头盔的鼹鼠出现的概率")]
    public float quickChance = 0.05f;

    [Tooltip("戴头盔的鼹鼠出现的概率")] public float helmetChance = 0.2f;

    [Tooltip("游戏开始前的等待时间（Ready?GO!）")] public float startDelay = 1;

    [Tooltip("剩余时间")] public float timeLeft = 30;

    [Tooltip("显示时间的文本对象")] public Text timeText;

    [Tooltip("鼹鼠出现位置的列表")] public List<Transform> spawnPositions;

    [Tooltip("目标（鼹鼠）的列表")] public Transform[] moles;

    [Tooltip("同时显示的目标数量")] public int maximumTargets = 5;

    [Tooltip("显示目标之前的等待时间")] public float showDelay = 3;

    internal float showDelayCount = 0;

    [Tooltip("隐藏目标之前的等待时间")] public float hideDelay = 2;

    [Tooltip("击中目标时获得的分数。随着击中的目标数量增加，分数会递增")]
    public int hitTargetBonus = 10;

    [Tooltip("计算当前连击数，每次击中都会使得奖励倍数增加。当目标隐藏时，连击数会重置")]
    internal int streak = 1;
    
    [Tooltip("玩家的得分")] public int score = 0;

    [Tooltip("显示玩家当前得分的文本对象")] public Transform scoreText;

    [Tooltip("关卡列表，每个关卡都有自己的目标分数、目标限制和时间奖励")]
    [SerializeField]
    public Level[] levels;

    [Tooltip("当前所处的关卡。必须达到目标分数才能进入下一关")] 
    public int currentLevel = 0;

    internal bool isGameOver = false;
    

    internal bool isPaused;

    // 通用索引
    internal int index = 0;
    
    void Start()
    {
        isPaused = GameManager.Instance.isPaused;

        spawnPositions = new List<Transform>(GetComponentsInChildren<Transform>(true));

        // 移除当前物体自身的Transform组件
        spawnPositions.Remove(transform);

        // 更新得分
        UpdateScore();

        // 重置出现延迟
        showDelayCount = 0;

        // 检查当前所处的关卡
        UpdateLevel();
        
    }
    
    void Update()
    {
        // Delay the start of the game
        if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
        }
        else
        {
            //If the game is over, listen for the Restart and MainMenu buttons
            if (isGameOver == true)
            {
            }
            else
            {
                // Count down the time until game over
                if (timeLeft > 0)
                {
                    // Count down the time
                    timeLeft -= Time.deltaTime;

                    // Update the timer
                    UpdateTime();
                }

                // Keyboard and Gamepad controls
                if (isPaused == false)
                {
                }

                // Count down to the next target spawn
                if (showDelayCount > 0) showDelayCount -= Time.deltaTime;
                else
                {
                    // Reset the spawn delay count
                    showDelayCount = showDelay;

                    ShowTargets(maximumTargets);
                }
            }
        }
    }

    /// <summary>
    /// Updates the timer text, and checks if time is up
    /// </summary>
    void UpdateTime()
    {
        // Update the timer text
        if (timeText)
        {
            timeText.text = timeLeft.ToString("00");
        }

        // Time's up!
        if (timeLeft <= 0)
        {
            StartCoroutine(GameOver(0));
        }
    }

    /// <summary>
    /// Shows a random batch of targets. Due to the random nature of selection, some targets may be selected more than once making the total number of targets to appear smaller.
    /// </summary>
    /// <param name="targetCount">The maximum number of target that will appear</param>
    void ShowTargets(int targetCount)
    {
        // Remove any targets from previous levels
        Mole[] previousTargets = GameObject.FindObjectsOfType<Mole>();

        // Go through each object found, and remove it
        foreach (Mole previousTarget in previousTargets)
        {
            Destroy(previousTarget.gameObject);
        }

        // Limit the number of tries when showing targets, so we don't get stuck in an infinite loop
        int maximumTries = targetCount * 5;

        // Show several targets that are within the game area
        while (targetCount > 0 && maximumTries > 0)
        {
            maximumTries--;

            // Choose a random target
            int randomTarget = Mathf.FloorToInt(Random.Range(0, moles.Length));

            // Choose a random spawn position
            int randomPosition = Mathf.FloorToInt(Random.Range(0, spawnPositions.Count));

            int positionChangeTries = spawnPositions.Count;

            // If the random spawn position is occupied by another target, go to the next position
            while (spawnPositions[randomPosition].GetComponentInChildren<Mole>() && positionChangeTries > 0)
            {
                // Go to the next available position
                if (randomPosition < spawnPositions.Count - 1) randomPosition++;
                else randomPosition = 0;

                // Reduce from the number of tries
                positionChangeTries--;
            }

            if (!spawnPositions[randomPosition].GetComponentInChildren<Mole>())
            {
                // Create the target object at the spawn position
                Transform newTarget = Instantiate(moles[randomTarget], spawnPositions[randomPosition].position,
                    Quaternion.identity);

                // Put the target inside the spawn position object
                newTarget.SetParent(spawnPositions[randomPosition]);

                // Show a random animation state for the spawned target
                if (Random.value < quickChance) newTarget.SendMessage("ShowQuick", hideDelay);
                else if (Random.value < helmetChance) newTarget.SendMessage("ShowHelmet", hideDelay);
                else newTarget.SendMessage("ShowMole", hideDelay);

                targetCount--;
            }
        }

        // Reset the streak when showing a batch of new targets
        streak = 1;
    }

    /// <summary>
    /// Give a bonus when the target is hit. The bonus is multiplied by the number of targets on screen
    /// </summary>
    /// <param name="hitSource">The target that was hit</param>
    void HitBonus(Transform hitSource)
    {
        // Increase the hit streak
        streak++;

        // Add the bonus to the score
        ChangeScore(hitTargetBonus * streak * hitSource.GetComponent<Mole>().bonusMultiplier);
    }

    /// <summary>
    /// Change the score
    /// </summary>
    /// <param name="changeValue">Change value</param>
    void ChangeScore(int changeValue)
    {
        score += changeValue;

        //Update the score
        UpdateScore();
    }

    /// <summary>
    /// Updates the score value and checks if we got to the next level
    /// </summary>
    void UpdateScore()
    {
        //Update the score text
        if (scoreText) scoreText.GetComponent<Text>().text = score.ToString();

        // If we reached the required number of points, level up!
        if (score >= levels[currentLevel].scoreToNextLevel)
        {
            if (currentLevel < levels.Length - 1) LevelUp();
        }
    }


    /// <summary>
    /// Levels up, and increases the difficulty of the game
    /// </summary>
    void LevelUp()
    {
        currentLevel++;

        // Update the level attributes
        UpdateLevel();

    }

    /// <summary>
    /// Updates the level and sets some values like maximum targets, throw angle, and level text
    /// </summary>
    void UpdateLevel()
    {
        // Set the maximum number of targets
        maximumTargets = levels[currentLevel].maximumTargets;

        // Give time bonus for winning the level
        timeLeft += levels[currentLevel].timeBonus;

        // Update the timer
        UpdateTime();
    }
    
    /// <summary>
    /// Runs the game over event and shows the game over screen
    /// </summary>
    IEnumerator GameOver(float delay)
    {
        isGameOver = true;

        yield return new WaitForSeconds(delay);

        //Show the game over screen
    }
}