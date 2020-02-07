using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Capture : MonoBehaviour
{    
    [SerializeField] private List<Enemy> _enemyList;    
    [SerializeField] private UnityEvent _enemiesCaught;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AccelerationEndCounter _accelerationEndCounter;

    private int _numberEnimes;

    private void Start()
    {
        _numberEnimes = _enemyList.Count;
        foreach (var enemy in _enemyList)
        {
            enemy.Deathing += () => OnDeath(enemy);
        }
    }

    private void Update()
    {
        KillEnemy(_enemyList);
    }

    private void AddKilledEnemies()
    {
        _numberEnimes -= 1;
        if (_numberEnimes == 0)
        {
            _enemiesCaught.Invoke();
        }
    }  
    
    private void OnDeath(Enemy enemy)
    {
        _playerMovement.IncreaseSpeed();
        _accelerationEndCounter.LaunchTimer();
        AddKilledEnemies();
        _enemyList.Remove(enemy);
    }

    private void KillEnemy(List<Enemy> enemyList)
    {
        foreach (var enemy in enemyList)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < 0.2f)
            {
                enemy.Death();                
            }
        }
    }    
}
