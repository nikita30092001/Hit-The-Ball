using System;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]private Score _score;

    public event Action<int> OnSavesLoaded;

    public void Save()
    {
        PlayerPrefs.SetInt("maxScore", _score.GetMaxScore());
        PlayerPrefs.Save();
    }

    public void Load()
    {
        int score = 0;
        if (PlayerPrefs.HasKey("maxScore"))
        {
            score = PlayerPrefs.GetInt("maxScore");
        }
        
        OnSavesLoaded?.Invoke(score);
    }
}
