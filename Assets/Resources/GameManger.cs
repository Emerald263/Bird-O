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
    private bool gameEnded=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {// show strat screen
        startScreen.SetActive(true);
        //hide end game screen
        endScreen.SetActive(false);
        //pause the game
        winScreen.SetActive(false);
        gameStarted=false;
        gameEnded=false;
        Time.timeScale = 0f;
        UpdateTimer();
        UpdateWormText();
    }
    void Update()
    {
        if (gameStarted == false)
            return;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
    
        UpdateTimer();

    }
    public void StartGame()
    {
        Debug.Log("start button works");
        startScreen.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1f;

    }
    public void gameOver()
    {
        gameStarted = false;
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void WinGame()
    {
        gameStarted = false;
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void WormDefeated()
    {
        wormsEaten++;
        if (wormText != null)
        {
            wormText.text = "Worm Eaten:" + wormsEaten;
        }
    }
}
