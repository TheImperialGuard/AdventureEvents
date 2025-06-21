using System;
using System.Collections.Generic;

public class EnemyStorage
{
    private List<Enemy> _enemies = new List<Enemy>();

    public int EnemyCount => _enemies.Count;

    public void SpawnEnemy(Enemy enemy, params Func<bool>[] deathReasons)
    {
        _enemies.Add(enemy);

        foreach (Func<bool> reason in deathReasons)
            enemy.SetDeathReason(reason);

        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy) => _enemies.Remove(enemy);

    public void Deinizialize()
    {
        foreach (Enemy enemy in _enemies)
            enemy.Died -= OnEnemyDied;
    }
}
