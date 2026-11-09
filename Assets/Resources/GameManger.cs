using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMangerScript : MonoBehaviour
{
    public static GameMangerScript instance;
    public GameObject startScreen;
    public GameObject endScreen;
    public GameObject winScreen;
    public TMP_Text wormText;
    public TMP_Text timerText;
    public int wormsEaten = 0;
    public int wormsNeededForBoss = 5;
    public float timeLeft = 60f;
    private bool gameStarted = false;
    private bool gameEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {// show start screen
        startScreen.SetActive(true);
        //hide end game screen
        endScreen.SetActive(false);
        winScreen.SetActive(false);
        gameStarted = false;
        gameEnded = false;
        //pause the game
        Time.timeScale = 0f;
        UpdateTimer();
        UpdateWormText();
    }
    void Update()
    {
        if (gameStarted == false)
            return;
        if (gameEnded == true) return;
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            UpdateTimer();
            gameOver();
            return;
        }
        UpdateTimer();

    }
    public void StartGame()
    {
        Debug.Log("start button works");
        startScreen.SetActive(false);
        gameStarted = true;
        gameEnded = false;
        Time.timeScale = 1f;

    }
    public void gameOver()
    {
        if (gameEnded == true)
            return;
        Debug.Log("Game over screen works");
        gameStarted = false;
        gameEnded = true;
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void WinGame()
    {
        if (gameEnded == true)
            return;
        gameStarted = false;
        gameEnded = true;
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("you win");
    }
    public void RestartGame()
    {
        Debug.Log("Restart button works");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void WormDefeated()
    {
        wormsEaten++;
        UpdateWormText();
    }
    void UpdateTimer()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left:" + Mathf.CeilToInt(timeLeft);

        }
    }
    void UpdateWormText()
    {
        if (wormText != null)
        {
            wormText.text = "Worm Eaten:" + wormsEaten;
        }
    }
}
