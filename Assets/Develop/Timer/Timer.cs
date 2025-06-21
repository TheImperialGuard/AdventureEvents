using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action TimerStarted;
    public event Action TimerEnded;

    private float _timeLimit;
    private float _elapsedTime;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _process;

    private bool _isRunning;

    public Timer(MonoBehaviour coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }
    public float TimeLimit => _timeLimit;

    public void StartProcess(float time)
    {
        _isRunning = true;

        _timeLimit = time;

        if (_process != null)
            _coroutineRunner.StopCoroutine(_process);

        _process = _coroutineRunner.StartCoroutine(Process());
    }

    public void Pause() => _isRunning = false;

    public void Resume() => _isRunning = true;

    public void Restart() => _elapsedTime = 0;

    public void Stop()
    {
        _isRunning = true;
        _elapsedTime = _timeLimit;
    }

    public bool InProcess(out float elapsedTime)
    {
        if (_process == null)
        {
            elapsedTime = _timeLimit;
            return false;
        }

        elapsedTime = _elapsedTime;
        return true;
    }

    private IEnumerator Process()
    {
        TimerStarted?.Invoke();

        _elapsedTime = 0;

        while (_elapsedTime < _timeLimit)
        {
            yield return new WaitUntil(() => _isRunning == true);

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _timeLimit)
                _elapsedTime = _timeLimit;

            yield return null;
        }

        _process = null;

        TimerEnded?.Invoke();
    }
}
