using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI missedText;
    private int score = 0;
    private int missed = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(float points)
    {
        score += (int)points;
    }

    public void Missed()
    {
        missed++;
    }

    public void GameOver()
    {
        scoreText.text = "Score: " + score;
        missedText.text = "Missed: " + missed;
        score = 0;
        missed = 0;
    }

    public void Play()
    {
        DummyGenerator.Instance.PrepareForGame();
        Invoke(nameof(StartGame), 3f);
    }

    public void StartGame()
    {
        DummyGenerator.Instance.Play();
    }
}
