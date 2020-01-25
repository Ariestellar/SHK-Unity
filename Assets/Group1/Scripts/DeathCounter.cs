using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] private int _countEnemy;
    [SerializeField] private UnityEvent _killAllEnemies;

    public event UnityAction OnAllEnemiesDead
    {
        add => _killAllEnemies.AddListener(value);
        remove => _killAllEnemies.RemoveListener(value);
    }

    public void DecreaseCounter()
    {
        _countEnemy -= 1;
        if (_countEnemy == 0)
            _killAllEnemies.Invoke();
    }
}
