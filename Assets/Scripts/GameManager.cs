using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject reset;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject GameOverUI;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        highScoreText.text = "High-Score\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();

        Pause();
    }

    public void Play()
    {        
        score = 0;
        scoreText.text = score.ToString();
        highScoreText.text = "High-Score\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();

        start.SetActive(false);
        GameOverUI.SetActive(false);
        reset.SetActive(false);
        exit.SetActive(false);

        Time.timeScale = 1f;
        movement.enabled = true;    

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        movement.enabled = false;
        start.SetActive(true);
        reset.SetActive(true);
        exit.SetActive(true);
    }
    public void GameOver()
    {
        GameOverUI.SetActive(true);        
        
        Pause();
    }

    public void Exit()
    {        
        Application.Quit();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score >= PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High-Score\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "High-Score\nXX";
    }

}
