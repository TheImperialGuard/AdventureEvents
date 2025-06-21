using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimerView : MonoBehaviour
{
    [SerializeField] private TimerController _timer;

    [SerializeField] private LayoutGroup _view;

    [SerializeField] private GameObject _lifeIconPrefab;

    private float _elapsedTime;

    private bool _running;

    private Queue<GameObject> _iconsList = new Queue<GameObject>();

    private void Update()
    {
        if (_timer.InProcess(out float elapsedTime))
        {
            _elapsedTime = elapsedTime;

            if (_running == false)
                CreateLifes();

            _running = true;

            CalculateLifes();
        }
        else
        {
            if (_running == true)
                DestroyLifes();

            _running = false;
        }
    }

    private void DestroyLifes()
    {
        if ( _iconsList.Count > 0 )
            foreach (GameObject icon in _iconsList )
                Destroy(icon.gameObject);

        _iconsList.Clear();
    }

    private void CreateLifes()
    {
        for (float i = 0; i < _timer.TimeLimit; i++)
        {
            GameObject icon = Instantiate(_lifeIconPrefab, _view.transform);

            _iconsList.Enqueue(icon);
        }
    }

    private void CalculateLifes()
    {
        GameObject icon;

        while (_timer.TimeLimit - _elapsedTime + 1 < _iconsList.Count)
        {
            icon = _iconsList.Dequeue();
            Destroy(icon);
        }

        if (_timer.TimeLimit - _elapsedTime > _iconsList.Count)
        {
            CreateLifes();
        }
    }
}
