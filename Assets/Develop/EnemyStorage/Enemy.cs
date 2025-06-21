using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    private Func<bool> _deathReason;

    [field: SerializeField] public bool IsDead { get; private set; }

    public float LifeTime { get; private set; }

    private void Awake()
    {
        IsDead = false;
    }

    private void Update()
    {
        LifeTime += Time.deltaTime;

        if (_deathReason != null)
        {
            Delegate[] invocationList = _deathReason.GetInvocationList();

            foreach (Func<bool> invocation in invocationList)
                if (invocation.Invoke())
                {
                    Died?.Invoke(this);
                    Destroy(gameObject);
                }
        }
    }

    public void SetDeathReason(Func<bool> reason) => _deathReason += reason;

    public void Kill() => IsDead = true;

    private void OnDestroy()
    {
        _deathReason = null;
    }
}
