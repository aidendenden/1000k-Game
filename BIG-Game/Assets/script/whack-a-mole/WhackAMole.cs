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

    [Tooltip("How fast the player object moves. This is only for keyboard and gamepad controls")]
    public float playerObjectSpeed = 15;

    // The player animator holds all the animations of the player object
    internal Animator playerAnimator;

    // Are we using the mouse now?
    internal bool usingMouse = false;

    // The position we are aiming at now
    internal Vector3 aimPosition;

    [Tooltip("The chance for a quick mole to appear. This overrides the chance for a mole with a helmet to appear")]
    public float quickChance = 0.05f;

    [Tooltip("The chance for a mole with a helmet to appear")]
    public float helmetChance = 0.2f;

    [Tooltip("How long to wait before starting the game. Ready?GO! time")]
    public float startDelay = 1;

    [Tooltip("The effect displayed before starting the game")]
    public Transform readyGoEffect;

    [Tooltip("How many seconds are left before game over")]
    public float timeLeft = 30;

    [Tooltip("The text object that displays the time")]
    public Text timeText;

    [Tooltip("A list of positions where the targets can appear")]
    public Transform[] spawnPositions = Array.Empty<Transform>();

    [Tooltip("A list of targets ( The moles that appear and hide in the holes )")]
    public Transform[] moles;

    [Tooltip("How many targets to show at once")]
    public int maximumTargets = 5;

    [Tooltip("How long to wait before showing the targets")]
    public float showDelay = 3;

    internal float showDelayCount = 0;

    [Tooltip("How long to wait before hiding the targets again")]
    public float hideDelay = 2;

    internal float hideDelayCount = 0;

    [Tooltip("The attack button, click it or tap it to attack with the hammer")]
    public string attackButton = "Fire1";

    [Tooltip("How many points we get when we hit a target. This bonus is increased as we hit more targets")]
    public int hitTargetBonus = 10;

    [Tooltip(
        "Counts the current hit streak, which multiplies your bonus for each hit. The streak is reset after the targets hide")]
    internal int streak = 1;

    [Tooltip("The bonus effect that shows how much bonus we got when we hit a target")]
    public Transform bonusEffect;

    [Tooltip("The score of the player")] public int score = 0;

    [Tooltip("The score text object which displays the current score of the player")]
    public Transform scoreText;

    internal int highScore = 0;
    internal int scoreMultiplier = 1;

    [Tooltip("A list of levels, each with its own target score, target limit, and time bonus")]
    public Level[] levels;

    [Tooltip("The current level we are on. We must reach the target score in order to go to the next level")]
    public int currentLevel = 0;

    [Tooltip(
        "If you set this to true the game will continue forever after the last level in the list. Otherwise you will get the victory screen after the last level")]
    public bool isEndless = false;

    // Various canvases for the UI
    public Transform gameCanvas;
    public Transform progressCanvas;
    public Transform pauseCanvas;
    public Transform gameOverCanvas;
    public Transform victoryCanvas;

    // Is the game over?
    internal bool isGameOver = false;
    

    // Various sounds and their source
    public AudioClip soundLevelUp;
    public AudioClip soundGameOver;
    public AudioClip soundVictory;
    public string soundSourceTag = "GameController";
    internal GameObject soundSource;

    // The button that will restart the game after game over
    public string confirmButton = "Submit";

    // The button that pauses the game. Clicking on the pause button in the UI also pauses the game
    public string pauseButton = "Cancel";
    internal bool isPaused = false;

    // A general use index
    internal int index = 0;

    //public Transform slowMotionEffect;

    void Awake()
    {
        // Activate the pause canvas early on, so it can detect info about sound volume state
        if (pauseCanvas) pauseCanvas.gameObject.SetActive(true);
        
    }

    /// <summary>
    /// Start is only called once in the lifetime of the behaviour.
    /// The difference between Awake and Start is that Start is only called if the script instance is enabled.
    /// This allows you to delay any initialization code, until it is really needed.
    /// Awake is always called before any Start functions.
    /// This allows you to order initialization of scripts
    /// </summary>
    void Start()
    {
        spawnPositions = GetComponentsInChildren<Transform>(true);
        
        // 移除当前物体自身的Transform组件
        //spawnPositions.Remove(transform);
        
        //Update the score
        UpdateScore();

        //Hide the cavases
        if (gameOverCanvas) gameOverCanvas.gameObject.SetActive(false);
        if (victoryCanvas) victoryCanvas.gameObject.SetActive(false);
        if (pauseCanvas) pauseCanvas.gameObject.SetActive(false);

        //Get the highscore for the player

        highScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "HighScore", 0);

        //Assign the sound source for easier access
        if (GameObject.FindGameObjectWithTag(soundSourceTag))
            soundSource = GameObject.FindGameObjectWithTag(soundSourceTag);

        // Reset the spawn delay
        showDelayCount = 0;

        // Check what level we are on
        UpdateLevel();

        // Move the targets from one side of the screen to the other, and then reset them
        /*foreach ( Transform movingTarget in moles )
        {
            movingTarget.SendMessage("HideMole");
        }*/

        // Create the ready?GO! effect
        if (readyGoEffect) Instantiate(readyGoEffect);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
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
                //The jump button restarts the game
                if (Input.GetButtonDown(confirmButton))
                {
                    Restart();
                }

                //The pause button goes to the main menu
                if (Input.GetButtonDown(pauseButton))
                {
                    MainMenu();
                }
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
                    // // If we move the mouse in any direction, then mouse controls take effect
                    // if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0 ||
                    //     Input.GetMouseButtonDown(0) || Input.touchCount > 0) usingMouse = true;
                    //
                    // // We are using the mouse, hide the playerObject
                    // if (usingMouse == true)
                    // {
                    //     // Calculate the mouse/tap position
                    //     aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //
                    //     // Make sure it's 2D
                    //     aimPosition.z = 0;
                    // }
                    //
                    // // If we press gamepad or keyboard arrows, then mouse controls are turned off
                    // if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                    // {
                    //     usingMouse = false;
                    // }
                    //
                    // // Move the playerObject based on gamepad/keyboard directions
                    // aimPosition += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), aimPosition.z) *
                    //                playerObjectSpeed * Time.deltaTime;
                    //
                    // // Limit the position of the playerObject to the edges of the screen
                    // // Limit to the left screen edge
                    // if (aimPosition.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x)
                    //     aimPosition = new Vector3(Camera.main.ScreenToWorldPoint(Vector3.zero).x, aimPosition.y,
                    //         aimPosition.z);
                    //
                    // // Limit to the right screen edge
                    // if (aimPosition.x > Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x)
                    //     aimPosition = new Vector3(Camera.main.ScreenToWorldPoint(Vector3.right * Screen.width).x,
                    //         aimPosition.y, aimPosition.z);
                    //
                    // // Limit to the bottom screen edge
                    // if (aimPosition.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
                    //     aimPosition = new Vector3(aimPosition.x, Camera.main.ScreenToWorldPoint(Vector3.zero).y,
                    //         aimPosition.z);
                    //
                    // // Limit to the top screen edge
                    // if (aimPosition.y > Camera.main.ScreenToWorldPoint(Vector3.up * Screen.height).y)
                    //     aimPosition = new Vector3(aimPosition.x,
                    //         Camera.main.ScreenToWorldPoint(Vector3.up * Screen.height).y, aimPosition.z);
                    //
                    // // Place the playerObject at the position of the mouse/tap, with an added offset
                    // //playerObject.position = aimPosition;
                    //
                    // playerObject.eulerAngles = Vector3.forward * (playerObject.position.x - aimPosition.x) * -10;
                    //
                    // // Move the hammer towards the aim posion
                    // //if ( Vector3.Distance(playerObject.position, aimPosition) > Time.deltaTime * playerObjectSpeed )    playerObject.position = Vector3.MoveTowards(playerObject.position, aimPosition, Time.deltaTime * playerObjectSpeed);
                    // //else    playerObject.position = aimPosition;
                    // playerObject.position = aimPosition;
                    // // If we press the shoot button, SHOOT!
                    // //if ( usingMouse == false && Input.GetButtonDown(attackButton) )    Shoot();
                    //
                    // if (playerObject && !EventSystem.current.IsPointerOverGameObject() &&
                    //     Input.GetButtonUp(attackButton))
                    // {
                    //     playerAnimator.Play("HammerDown");
                    // }
                }

                // Count down to the next target spawn
                if (showDelayCount > 0) showDelayCount -= Time.deltaTime;
                else
                {
                    // Reset the spawn delay count
                    showDelayCount = showDelay;

                    ShowTargets(maximumTargets);
                }

                //Toggle pause/unpause in the game
                if (Input.GetButtonDown(pauseButton))
                {
                    if (isPaused == true) Unpause();
                    else Pause(true);
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
            int randomPosition = Mathf.FloorToInt(Random.Range(0, spawnPositions.Length));

            int positionChangeTries = spawnPositions.Length;

            // If the random spawn position is occupied by another target, go to the next position
            while (spawnPositions[randomPosition].GetComponentInChildren<Mole>() && positionChangeTries > 0)
            {
                // Go to the next available position
                if (randomPosition < spawnPositions.Length - 1) randomPosition++;
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
        // If we have a bonus effect
        if (bonusEffect)
        {
            // Create a new bonus effect at the hitSource position
            Transform newBonusEffect =
                Instantiate(bonusEffect, hitSource.position + Vector3.up, Quaternion.identity) as Transform;

            // Display the bonus value multiplied by a streak
            if (hitSource.GetComponent<Mole>().bonusMultiplier >= 0)
                newBonusEffect.Find("Text").GetComponent<Text>().text = "+" +
                                                                        (hitTargetBonus * streak *
                                                                         hitSource.GetComponent<Mole>()
                                                                             .bonusMultiplier).ToString();
            else
                newBonusEffect.Find("Text").GetComponent<Text>().text =
                    (hitTargetBonus * streak * hitSource.GetComponent<Mole>().bonusMultiplier).ToString();

            // Rotate the bonus text slightly
            newBonusEffect.eulerAngles = Vector3.forward * Random.Range(-10, 10);
        }

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
            else if (isEndless == false) StartCoroutine(Victory(0));
        }

        // Update the progress bar to show how far we are from the next level
        if (progressCanvas)
        {
            if (currentLevel == 0)
                progressCanvas.GetComponent<Image>().fillAmount =
                    score * 1.0f / levels[currentLevel].scoreToNextLevel * 1.0f;
            else
                progressCanvas.GetComponent<Image>().fillAmount = (score - levels[currentLevel - 1].scoreToNextLevel) *
                    1.0f / (levels[currentLevel].scoreToNextLevel - levels[currentLevel - 1].scoreToNextLevel) * 1.0f;
        }
    }

    /// <summary>
    /// Set the score multiplier ( Get double score for hitting and destroying targets )
    /// </summary>
    void SetScoreMultiplier(int setValue)
    {
        // Set the score multiplier
        scoreMultiplier = setValue;
    }

    /// <summary>
    /// Levels up, and increases the difficulty of the game
    /// </summary>
    void LevelUp()
    {
        currentLevel++;

        // Update the level attributes
        UpdateLevel();

        //Run the level up effect, displaying a sound
        LevelUpEffect();
    }

    /// <summary>
    /// Updates the level and sets some values like maximum targets, throw angle, and level text
    /// </summary>
    void UpdateLevel()
    {
        // Display the current level we are on
        if (progressCanvas) progressCanvas.Find("Text").GetComponent<Text>().text = (currentLevel + 1).ToString();

        // Set the maximum number of targets
        maximumTargets = levels[currentLevel].maximumTargets;

        // Give time bonus for winning the level
        timeLeft += levels[currentLevel].timeBonus;

        // Update the timer
        UpdateTime();
    }

    /// <summary>
    /// Shows the effect associated with leveling up ( a sound and text bubble )
    /// </summary>
    void LevelUpEffect()
    {
        // Show the time bonus effect when we level up
        if (bonusEffect)
        {
            // Create a new bonus effect at the hitSource position
            Transform newBonusEffect = Instantiate(bonusEffect) as Transform;

            newBonusEffect.position = new Vector3(0, Camera.main.ScreenToWorldPoint(timeText.transform.position).y, 0);

            // Display the bonus value multiplied by a streak
            newBonusEffect.Find("Text").GetComponent<Text>().text =
                "EXTRA TIME!\n+" + levels[currentLevel].timeBonus.ToString();
        }

        //If there is a source and a sound, play it from the source
        if (soundSource && soundLevelUp)
        {
            soundSource.GetComponent<AudioSource>().pitch = 1;

            soundSource.GetComponent<AudioSource>().PlayOneShot(soundLevelUp);
        }
    }

    /// <summary>
    /// Pause the game, and shows the pause menu
    /// </summary>
    /// <param name="showMenu">If set to <c>true</c> show menu.</param>
    public void Pause(bool showMenu)
    {
        isPaused = true;

        //Set timescale to 0, preventing anything from moving
        Time.timeScale = 0;

        //Show the pause screen and hide the game screen
        if (showMenu == true)
        {
            if (pauseCanvas) pauseCanvas.gameObject.SetActive(true);
            if (gameCanvas) gameCanvas.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void Unpause()
    {
        isPaused = false;

        //Set timescale back to the current game speed
        Time.timeScale = 1;

        //Hide the pause screen and show the game screen
        if (pauseCanvas) pauseCanvas.gameObject.SetActive(false);
        if (gameCanvas) gameCanvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// Runs the game over event and shows the game over screen
    /// </summary>
    IEnumerator GameOver(float delay)
    {
        isGameOver = true;

        yield return new WaitForSeconds(delay);

        //Remove the pause and game screens
        if (pauseCanvas) pauseCanvas.gameObject.SetActive(false);
        if (gameCanvas) gameCanvas.gameObject.SetActive(false);

        //Show the game over screen
        if (gameOverCanvas)
        {
            //Show the game over screen
            gameOverCanvas.gameObject.SetActive(true);

            //Write the score text
            gameOverCanvas.Find("Base/TextScore").GetComponent<Text>().text = "SCORE " + score.ToString();

            //Check if we got a high score
            if (score > highScore)
            {
                highScore = score;

                //Register the new high score

                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "HighScore", score);

            }

            //Write the high sscore text
            gameOverCanvas.Find("Base/TextHighScore").GetComponent<Text>().text = "HIGH SCORE " + highScore.ToString();

            //If there is a source and a sound, play it from the source
            if (soundSource && soundGameOver)
            {
                soundSource.GetComponent<AudioSource>().pitch = 1;

                soundSource.GetComponent<AudioSource>().PlayOneShot(soundGameOver);
            }
        }
    }

    /// <summary>
    /// Runs the victory event and shows the victory screen
    /// </summary>
    IEnumerator Victory(float delay)
    {
        isGameOver = true;

        yield return new WaitForSeconds(delay);

        //Remove the pause and game screens
        if (pauseCanvas) Destroy(pauseCanvas.gameObject);
        if (gameCanvas) Destroy(gameCanvas.gameObject);

        //Show the game over screen
        if (victoryCanvas)
        {
            //Show the game over screen
            victoryCanvas.gameObject.SetActive(true);

            //Write the score text
            victoryCanvas.Find("Base/TextScore").GetComponent<Text>().text = "SCORE " + score.ToString();

            //Check if we got a high score
            if (score > highScore)
            {
                highScore = score;

                //Register the new high score

                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "HighScore", score);

            }

            //Write the high sscore text
            victoryCanvas.Find("Base/TextHighScore").GetComponent<Text>().text = "HIGH SCORE " + highScore.ToString();

            //If there is a source and a sound, play it from the source
            if (soundSource && soundVictory)
            {
                soundSource.GetComponent<AudioSource>().pitch = 1;

                soundSource.GetComponent<AudioSource>().PlayOneShot(soundVictory);
            }
        }
    }

    /// <summary>
    /// Restart the current level
    /// </summary>
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Restart the current level
    /// </summary>
    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
