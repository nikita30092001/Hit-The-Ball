using System;
using UnityEngine;

[RequireComponent(typeof(MultiplierHandler), typeof(SaveSystem))]
public class Game: MonoBehaviour
{
    private MultiplierHandler _multiplier;
    private SaveSystem _saveSystem;

    [SerializeField] private Score _score;
    [SerializeField] private Ball _ball;
    [SerializeField] private DeadZoneContactHandler _deadZoneContactHandler;
    [SerializeField] private ProgressBar _progressBar;

    [Header("UI")]
    [SerializeField] private Menu _menu;
    [SerializeField] private ScoreCanvas _scoreCanvas;

    public event Action OnFinishGame;

    private void Awake()
    {
        _multiplier = GetComponent<MultiplierHandler>();
        _saveSystem = GetComponent<SaveSystem>();
    }

    private void OnEnable()
    {
        _deadZoneContactHandler.OnDeadZoneContact += BallDrop;
        _menu.OnStartButtonClicked += SetActivity;
        _menu.OnExitButtonClicked += CloseGame;
    }

    private void OnDisable()
    {
        _deadZoneContactHandler.OnDeadZoneContact -= BallDrop;
        _menu.OnStartButtonClicked -= SetActivity;
        _menu.OnExitButtonClicked -= CloseGame;
    }

    private void Start()
    {
        _saveSystem.Load();
        Restart();
    }

    private void Restart()
    {
        PrepareBall();
        SetActivity(true);
        _score.Reset();
        _multiplier.Reset();
    }

    private void PrepareBall()
    {
        _ball.transform.position = Vector2.zero;
        _ball._rigidbody.bodyType = RigidbodyType2D.Static;
        _ball.gameObject.SetActive(false);
    }

    private void SetActivity(bool isMenuActive)
    {
        _menu.gameObject.SetActive(isMenuActive);
        _ball.gameObject.SetActive(!isMenuActive);
        _progressBar.gameObject.SetActive(!isMenuActive);
    }

    private void SetMaxScore()
    {
        _score.SetMaxScore();
    }

    private void BallDrop()
    {
        SetMaxScore();
        Restart();
        OnFinishGame?.Invoke();
    }

    private void CloseGame()
    {
        _saveSystem.Save();
        Application.Quit();
    }
}
