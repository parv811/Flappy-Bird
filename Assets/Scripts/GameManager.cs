using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject GameOverUI;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {        
        score = 0;
        scoreText.text = score.ToString();

        start.SetActive(false);
        GameOverUI.SetActive(false);

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
    }
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        start.SetActive(true);
        
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
