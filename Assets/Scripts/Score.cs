using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text _scoreText;
    private static int _score;

    void Start()
    {
        _scoreText = GetComponent<Text>();
    }
    
    void Update()
    {
        _scoreText.text = $"   Score: {_score}";
    }

    public static void AddScore(int value)
    {
        _score += value;
    }
}
