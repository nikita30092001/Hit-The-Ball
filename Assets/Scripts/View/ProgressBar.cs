using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{

    [SerializeField] private MultiplierHandler _multiplier;

    private Slider _slider => GetComponent<Slider>();

    private void OnEnable()
    {
        _multiplier.OnMultiplierChanged += SetMaxValue;
        _multiplier.OnTouchCountChanged += DrawBar;
    }

    private void OnDisable()
    {
        _multiplier.OnMultiplierChanged -= SetMaxValue;
        _multiplier.OnTouchCountChanged -= DrawBar;
    }

    private void DrawBar(int touchCount)
    {
        _slider.value = touchCount;
    }

    private void SetMaxValue(int maxValue)
    {
        _slider.value = 0;
        _slider.maxValue = maxValue;
    }
}
