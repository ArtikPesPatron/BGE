using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<Transform> _spawnerPoints;
    private List<Enemy> _enemies;
    private float _lastSpawn;

    public List<Transform> patrolPoints;
    public PlayerController player;
    public int maxEnemyOnLevel = 5;
    public float TimePerSpawn = 2;
    public Enemy enemyPrefab;

    private void EnemySpawn()
    {
        for(var i = 0; i<_enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }

        if (_enemies.Count >= maxEnemyOnLevel)
        {
            return;
        }
        else
        {
            if (Time.time - _lastSpawn < TimePerSpawn)
            {
                return;
            }
            else
            {
                CreateEnemy();
            }
        }
    }
    private void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _lastSpawn = Time.time;
    }

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _enemies = new List<Enemy>();
    }

    private void Update()
    {
        EnemySpawn();
    }
}
