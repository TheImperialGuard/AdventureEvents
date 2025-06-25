using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public bool IsDead { get; private set; }

    public float LifeTime { get; private set; }

    private void Awake()
    {
        IsDead = false;
    }

    private void Update()
    {
        LifeTime += Time.deltaTime;
    }

    public void Kill() => Destroy(gameObject);
}
