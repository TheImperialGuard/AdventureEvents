using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyStorage _enemyStorage;

    private void Awake()
    {
        _enemyStorage = new EnemyStorage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            _enemyStorage.SpawnEnemy(enemy, () => enemy.IsDead == true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            _enemyStorage.SpawnEnemy(enemy, () => enemy.IsDead == true || enemy.LifeTime > 5f);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            _enemyStorage.SpawnEnemy(enemy, () => _enemyStorage.EnemyCount > 10f);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            _enemyStorage.SpawnEnemy(enemy, () => enemy.LifeTime > 2f);
        }

        _enemyStorage.Update();

        Debug.Log(_enemyStorage.EnemyCount);
    }
}
