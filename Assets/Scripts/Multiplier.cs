using System;
using UnityEngine;

public class MultiplierHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Wall[] _walls;

    public int Multiplier { get; private set; }
    public int TouchCount { get; private set; }

    public event Action<int> OnMultiplierChanged;
    public event Action<int> OnTouchCountChanged;

    private void OnEnable()
    {
        _ball.OnBallMoved += CalculateTouchCount;
        foreach (var wall in _walls)
        {
            wall.OnWallsContact += Reset;
        }
    }

    private void OnDisable()
    {
        _ball.OnBallMoved -= CalculateTouchCount;
        foreach (var wall in _walls)
        {
            wall.OnWallsContact -= Reset;
        }
    }

    private void CalculateTouchCount()
    {
        TouchCount += 1;
        OnTouchCountChanged?.Invoke(TouchCount);
        ChangeMultiplier();
    }

    private void ChangeMultiplier()
    {
        if (TouchCount <= 32 && TouchCount % (Multiplier * 4) == 0)
        {
            Multiplier *= 2;
            TouchCount = 0;
            OnMultiplierChanged?.Invoke(Multiplier * 4);
        }
    }

    public void Reset()
    {
        TouchCount = 0;
        Multiplier = 1;
        OnTouchCountChanged?.Invoke(TouchCount);
        OnMultiplierChanged?.Invoke(Multiplier * 4);
    }
}
