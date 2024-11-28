using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private SoundSystem _soundSystem;

    public event Action<bool> OnStartButtonClicked;
    public event Action OnExitButtonClicked;

    public void StartButtonClick()
    {
        _soundSystem.StopSound();
        _soundSystem.PlaySound(Sound.StartSound);
        OnStartButtonClicked?.Invoke(false);
    }

    public void ExitButtonClick()
    {
        OnExitButtonClicked?.Invoke();
    }
}
