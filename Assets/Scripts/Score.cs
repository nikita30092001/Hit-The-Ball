using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private MultiplierHandler _multiplier;
    [SerializeField] private Ball _ball;
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private SaveSystem _saveSystem;

    private int _score;
    private int _maxScore;

    public event Action<int> OnScoreChanged;
    public event Action<int> OnMaxScoreChanged;

    private void OnEnable()
    {
        _ball.OnBallMoved += Add;
        _saveSystem.OnSavesLoaded += LoadMaxScore;
    }

    private void OnDisable()
    {
        _ball.OnBallMoved -= Add;
    }

    public void SetMaxScore()
    {
        if (_score  > _maxScore)
        {
            _soundSystem.PlaySound(Sound.FinishSound);
            _maxScore = Mathf.Max(_score, _maxScore);
            OnMaxScoreChanged?.Invoke(_maxScore);
        }
    }

    private void LoadMaxScore(int score)
    {
        _maxScore = score;
    }

    public int GetMaxScore()
    {
        return _maxScore;
    }

    private void Add()
    {
        _score += _multiplier.Multiplier;
        OnScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
        OnMaxScoreChanged?.Invoke(_maxScore);
    }
}
