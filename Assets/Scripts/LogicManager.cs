using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public static LogicManager instance  {get; private set;}
    public GameObject pauseMenuUI;
    public static bool isPaused = false;
    public int score;
    public TMPro.TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            print("escape pressed");
            if (isPaused) {
                resumeGame();
            } else {
                pauseGame();
            }
        }
    }

    public void addScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.instance.setBackgroundLevelLow();
        isPaused = true;
    }

    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.instance.setBackgroundLevelNormal();
        isPaused = false;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
		isPaused = false;
        SceneManager.LoadScene("Menu");
    }
}
