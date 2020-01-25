using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{    
    [SerializeField] private List<GameObject> _enemyList;
    [SerializeField] private DeathCounter _deathCounter;
    [SerializeField] private PlayerMovement _playerMovement;

    public void Awake()
    {
        foreach (var enemy in _enemyList)
        {
            enemy.GetComponent<Enemy>().OnEnemyDead += () => EnemyHandler(enemy);            
        }
    }

    private void Update()
    {
        KillEnemy();
    }

    private void RemoveEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().OnEnemyDead -= () => EnemyHandler(enemy);        
        _enemyList.Remove(enemy);
    }       

    private void KillEnemy()
    {
        foreach (var enemy in _enemyList)
        {
            if (enemy == null) 
            {
                continue;
            }
            else if (Vector3.Distance(transform.position, enemy.transform.position) < 0.2f)
            {
                enemy.GetComponent<Enemy>().Death();
            }
        }       
    }

    private void EnemyHandler(GameObject enemy)
    {
        _playerMovement.IncreaseSpeed();
        _deathCounter.DecreaseCounter();
        RemoveEnemy(enemy);
    }
}
