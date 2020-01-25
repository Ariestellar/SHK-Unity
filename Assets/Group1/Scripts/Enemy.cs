using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyDeath;

    public event UnityAction OnEnemyDead
    {
        add => _enemyDeath.AddListener(value);
        remove => _enemyDeath.RemoveListener(value);
    }

    public void Death()
    {
        _enemyDeath.Invoke();
        Destroy(gameObject);
    }
}
