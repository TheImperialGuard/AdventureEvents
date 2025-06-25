using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public event Action TimerStarted
    {
        add => _timer.TimerStarted += value;
        remove => _timer.TimerStarted -= value;
    }

    public event Action TimerEnded
    {
        add => _timer.TimerEnded += value;
        remove => _timer.TimerEnded -= value;
    }

    [SerializeField] private TMP_InputField _inputField;

    private const string TimerFormat = "00.00";
    private const string TimerDecimalSeparatort = ":";

    NumberFormatInfo _nfi = new NumberFormatInfo();

    private Timer _timer;

    public float TimeLimit => _timer.TimeLimit;

    private void Awake()
    {
        _timer = new Timer(this);

        _timer.TimerStarted += OnTimerStarted;
        _timer.TimerEnded += OnTimerEnded;

        _nfi.NumberDecimalSeparator = TimerDecimalSeparatort;
    }

    private void OnDestroy()
    {
        _timer.TimerStarted -= OnTimerStarted;
        _timer.TimerEnded -= OnTimerEnded;
    }

    private void Update()
    {
        if (_timer.InProcess(out float elapsedTime))
            _inputField.text = (_timer.TimeLimit - elapsedTime).ToString(TimerFormat, _nfi);
    }

    public void Play()
    {
        _timer.Resume();

        if (TryPlay(out float timeLimit))
            _timer.StartProcess(timeLimit);
    }

    public void Pause() => _timer.Pause();

    public void Restart() => _timer.Restart();

    public void Stop() => _timer.Stop();

    public bool InProcess(out float elapsedTime) => _timer.InProcess(out elapsedTime);

    private void OnTimerEnded()
    {
        _inputField.interactable = true;
        Debug.Log("Timer Ended");
    }

    private void OnTimerStarted()
    {
        _inputField.interactable = false;
        Debug.Log("Timer Started");
    }

    private bool TryPlay(out float timeLimit) => float.TryParse(_inputField.text, out timeLimit);
}
