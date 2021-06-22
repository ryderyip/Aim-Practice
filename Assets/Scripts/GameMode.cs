using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject difficultySelection;
    public TextMeshProUGUI circleSizeText;
    public TextMeshProUGUI spawnRateText;
    public TextMeshProUGUI durationText;
    public Settings settings;

    void Start()
    {
        UpdateSizeText(settings.targetSize);
        UpdateSpawnRateText();
        UpdateDurationText();
    }

    public void StartGame()
    {
        settings.SetCircleSize();
        SceneManager.LoadScene("Main Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void UpdateDurationText()
    {
        durationText.text = "Duration: " + Math.Round(settings.duration, 2) + "s";
    }

    public void MoreTime()
    {
        if(settings.duration < 120)
        {
            settings.duration += 30;
            UpdateDurationText();
        }
    }

    public void LessTime()
    {
        if (settings.duration > 30)
        {
            settings.duration -= 30;
            UpdateDurationText();
        }
    }

    private void UpdateSpawnRateText()
    {
        spawnRateText.text = "Spawn Rate: " + Math.Round(settings.spawnRate, 2) + "s";
    }

    public void SpeedUp()
    {   
        if(settings.spawnRate > 0.25f)
        {
            settings.spawnRate -= 0.05f;
            UpdateSpawnRateText();
        }
    }

    public void SpeedDown()
    {
        if (settings.spawnRate < 2)
        {
            settings.spawnRate += 0.05f;
            UpdateSpawnRateText();
        }
    }

    private void UpdateSizeText(float size)
    {
        circleSizeText.text = "Circle Size: " + Math.Round(size, 1);
    }

    public void SizeUp()
    {
        if (settings.targetSize < 2)
        {
            settings.targetSize += 0.1f;
            UpdateSizeText(settings.targetSize);
        }
    }

    public void SizeDown()
    {
        if (settings.targetSize > 0.5f)
        {
            settings.targetSize -= 0.1f;
            UpdateSizeText(settings.targetSize);
        }
    }
}
