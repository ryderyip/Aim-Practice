using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject circlePrefab;
    public Score score;
    public GameObject mainGame;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private GameObject circleSet;

    private float timeRemaining;
    public float spawnRate;
    private float maxPos = 4;
    private bool isGameActive = false;
    private Coroutine timerCoroutine;
    private Settings settings;

    private void Update()
    {
        if (isGameActive)
        {
            CountDown();
            if (timeRemaining <= 0)
            {
                GameOver();
            }
        }
    }

    private void Start()
    {
        //Apply all settings
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        spawnRate = settings.spawnRate;
        timeRemaining = settings.duration;
        settings.SetCircleSize();

        circleSet = GameObject.Find("CircleSet");
        score = GameObject.Find("Score").GetComponent<Score>();

        isGameActive = true;
        timerCoroutine = StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void GameOver()
    {
        StopCoroutine(timerCoroutine);
        isGameActive = false;
        Destroy(circleSet);
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(circlePrefab, RandomPosition(), circlePrefab.transform.rotation, circleSet.transform);
        }
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-maxPos, maxPos), Random.Range(-maxPos, maxPos));
    }

    private void CountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        timerText.text = "Time: " + Mathf.Round(timeRemaining);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score.score += scoreToAdd;
        scoreText.text = "Score: " + score.score;
    }
}
