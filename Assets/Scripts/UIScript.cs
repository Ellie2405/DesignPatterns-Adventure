using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        UpdateScoreText();
        GameManager.ScoreUpdated += UpdateScoreText;
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Score = " + GameManager.Instance.Score;
    }
}
