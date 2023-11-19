using UnityEngine;
using System.Collections;


public class Mole : MonoBehaviour
{
    // 对游戏控制器的引用，第一次运行此脚本时会获取，并在其他相同类型的脚本中记住
    static GameObject gameController;

// 地鼠的动画部分。默认情况下，从此对象中获取
    internal Animator moleAnimator;

    [Tooltip("地鼠的头盔对象，从地鼠本身中分配")] public GameObject helmet;

    [Tooltip("头盔损坏时出现的破碎头盔。这是从项目面板中分配的")] public Transform brokenHelmet;

    [Tooltip("地鼠佩戴头盔时的生命值")] public int helmetHealth = 2;

// 地鼠不佩戴头盔时的生命值
    internal int health = 1;

    [Tooltip("击中此目标时的奖励倍数")] public int bonusMultiplier = 1;

    [Tooltip("可以击中此地鼠的对象的标签")] public string targetTag = "TouchPoint";

// 地鼠是否死亡？
    internal bool isDead = false;

// 在显示地鼠之前等待的时间
    internal float showTime = 0;

// 在地鼠显示后等待多长时间再隐藏
    internal float hideDelay = 0;

    [Tooltip("显示地鼠时的动画名称")] public string animationShow = "MoleShow";

    [Tooltip("隐藏地鼠时的动画名称")] public string animationHide = "MoleHide";

    [Tooltip("地鼠死亡时的动画列表。从列表中随机选择一个动画")] public string[] animationDie = { "MoleSmack", "MoleWhack", "MoleThud" };

    // Use this for initialization
    void Start()
    {
        // Hold the gamcontroller object in a variable for quicker access
        if (gameController == null) gameController = GameObject.FindGameObjectWithTag("GameController");

        // The animator of the mole. This holds all the animations and the transitions between them
        moleAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update()
    {
        // Count down the time until the mole is hidden
        if (isDead == false && hideDelay > 0)
        {
            hideDelay -= Time.deltaTime;

            // If enough time passes, hide the mole
            if (hideDelay <= 0) HideMole();
        }
    }

    /// <summary>
    /// Raises the trigger enter2d event. Works only with 2D physics.
    /// </summary>
    /// <param name="other"> The other collider that this object touches</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we hit the correct target
        if (isDead == false && other.tag == targetTag)
        {
            // Give hit bonus for this target
            gameController.SendMessage("HitBonus", this.transform);

            // Change the health of the target
            ChangeHealth(-1);
        }
    }

    /// <summary>
    /// Changes the health of the target, and checks if it should die
    /// </summary>
    /// <param name="changeValue"></param>
    public void ChangeHealth(int changeValue)
    {
        // Chnage health value
        health += changeValue;

        if (health > 0)
        {
            // Animated the hit effect
            moleAnimator.Play("MoleHit", -1, 0f);
        }
        else
        {
            // Health reached 0, so the target is dead
            Die();
        }
    }

    /// <summary>
    /// Kills the object and gives it a random animation from a list of death animations
    /// </summary>
    public void Die()
    {
        // The mole is now dead. It can't move.
        isDead = true;

        // If there is a helment object, deactivate it and create a helmet break effect
        if (helmet && helmet.activeSelf == true)
        {
            // Create the helmet break effect
            if (brokenHelmet) Instantiate(brokenHelmet, helmet.transform.position, helmet.transform.rotation);

            // Deactivate the helmet object
            helmet.SetActive(false);
        }

        // Choose one of the death animations randomly
        if (animationDie.Length > 0)
            moleAnimator.Play(animationDie[Mathf.FloorToInt(Random.Range(0, animationDie.Length))]);
    }

    /// <summary>
    /// Hides the target, animating it and then sets it to hidden
    /// </summary>
    void HideMole()
    {
        // Play the hiding animation
        GetComponent<Animator>().Play(animationHide);
    }

    /// <summary>
    /// Destroys the target object ( this is called from the Animator Die clip )
    /// </summary>
    public void RemoveTarget()
    {
        Destroy(gameObject);
    }

    #region not use

    /// <summary>
    /// Shows the regular mole
    /// </summary>
    /// <returns>The target.</returns>
    public void ShowMole(float showDuration)
    {
        // The mole is not dead anymore, so it can appear from the hole
        isDead = false;

        // If the mole has a helmet, deactivate it
        if (helmet) helmet.SetActive(false);

        // Set the health of the mole to 1 hit
        health = 1;

        // Play the show animation
        GetComponent<Animator>().Play(animationShow);

        // Set how long to wait before hiding the mole again
        hideDelay = showDuration;
    }

    /// <summary>
    /// Shows the mole with a helmet
    /// </summary>
    /// <returns>The target.</returns>
    public void ShowHelmet(float showDuration)
    {
        // The mole is not dead anymore, so it can appear from the hole
        isDead = false;

        // If the mole has a helmet, deactivate it
        if (helmet) helmet.SetActive(true);

        // Set the health of the mole to the helmet health
        health = helmetHealth;

        // Play the show animation
        GetComponent<Animator>().Play(animationShow);

        // Set how long to wait before hiding the mole again
        hideDelay = showDuration;
    }

    /// <summary>
    /// Shows the quick mole
    /// </summary>
    /// <returns>The target.</returns>
    public void ShowQuick(float showDuration)
    {
        // The mole is not dead anymore, so it can appear from the hole
        isDead = false;

        // If the mole has a helmet, deactivate it
        if (helmet) helmet.SetActive(false);

        // Set the health of the mole to 1 hit
        health = 1;

        // Play the show animation
        GetComponent<Animator>().Play("MoleQuick");

        // Set how long to wait before hiding the mole again
        hideDelay = 0;
    }

    #endregion
}