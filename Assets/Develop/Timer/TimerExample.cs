using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private SliderTimerView _sliderView;
    [SerializeField] private LifeTimerView _lifeView;
    [SerializeField] private TimerControlPanel _controlPanel;

    private void Awake()
    {
        Timer timer = new Timer(this);

        _sliderView.Initialize(timer);
        _lifeView.Initialize(timer);
        _controlPanel.Initialize(timer);
    }
}
