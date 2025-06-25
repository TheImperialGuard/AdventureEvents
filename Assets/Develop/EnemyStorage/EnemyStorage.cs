using System;
using System.Collections.Generic;

public class EnemyStorage
{
    private Dictionary<Enemy, Func<bool>> _enemies = new Dictionary<Enemy, Func<bool>>();

    public int EnemyCount => _enemies.Count;

    public void SpawnEnemy(Enemy enemy, Func<bool> deathReasons) => _enemies.Add(enemy, deathReasons);

    public void Update()
    {
        foreach (KeyValuePair<Enemy, Func<bool>> enemy in _enemies)
            if (enemy.Value != null)
                if (enemy.Value.Invoke() == true)
                { 
                    Kill(enemy.Key); 
                    break;
                }
    }

    private void Kill(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.Kill();
    }
}
