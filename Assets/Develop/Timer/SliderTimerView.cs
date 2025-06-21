using UnityEngine;
using UnityEngine.UI;

public class SliderTimerView : MonoBehaviour
{
    [SerializeField] private TimerController _timer;

    [SerializeField] private RectTransform _view;

    [SerializeField] private Slider _sliderPrefab;

    private Slider _slider;

    private void Start()
    {
        _timer.TimerStarted += OnTimerStarted;
        _timer.TimerEnded += OnTimerEnded;
    }

    private void OnDestroy()
    {
        _timer.TimerStarted -= OnTimerStarted;
        _timer.TimerEnded -= OnTimerEnded;
    }

    private void Update()
    {
        if (_timer.InProcess(out float elapsedTime))
            _slider.value = elapsedTime/_timer.TimeLimit;
    }

    private void OnTimerEnded()
    {
        Destroy(_slider.gameObject);
    }

    private void OnTimerStarted()
    {
        _slider = Instantiate(_sliderPrefab, _view);
    }
}
