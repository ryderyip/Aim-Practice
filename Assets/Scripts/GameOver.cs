using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject ending;
    private TextMeshProUGUI endingScoreText;
    private GameObject score;
    private GameObject settings;

    void Start()
    {
        endingScoreText = ending.GetComponentInChildren<TextMeshProUGUI>();
        score = GameObject.Find("Score");
        settings = GameObject.Find("Settings");
        endingScoreText.text = "Score: " + score.GetComponent<Score>().score;
        
    }

    public void RestartGame()
    {
        Destroy(score);
        SceneManager.LoadScene("Main Game");
    }

    public void BackToMenu()
    {
        Destroy(score);
        Destroy(settings);
        SceneManager.LoadScene("Menu");
    }
}
