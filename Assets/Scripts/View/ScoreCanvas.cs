using TMPro;
using UnityEngine;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreValue;
    [SerializeField] private TMP_Text _maxScoreValue;

    private void OnEnable()
    {
        _score.OnScoreChanged += DrawScore;
        _score.OnMaxScoreChanged += DrawMaxScore;
    }

    private void OnDisable()
    {
        _score.OnScoreChanged -= DrawScore;
        _score.OnMaxScoreChanged -= DrawMaxScore;
    }

    private void DrawScore(int score)
    {
        _scoreValue.text = score.ToString();
    }

    private void DrawMaxScore(int score)
    {
        _maxScoreValue.text = score.ToString();
    }
}
