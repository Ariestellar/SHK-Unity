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

    private void Start()
    {        
        foreach (var enemy in _enemyList)
        {  
            enemy.Deathing += OnDeath;
        }
    }

    private void Update()
    {
        KillEnemy(_enemyList);
    }
    
    private void OnDeath(Enemy enemy)
    {
        _playerMovement.IncreaseSpeed();
        _accelerationEndCounter.LaunchTimer();        
        _enemyList.Remove(enemy);
        enemy.Deathing -= OnDeath;
    }

    private void KillEnemy(List<Enemy> enemyList)
    {
        foreach (var enemy in enemyList)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < 0.2f)
            {
                enemy.Death(enemy);
                if (enemyList.Count == 0)
                {
                    _enemiesCaught.Invoke();
                }
            }            
        }
    }    
}
