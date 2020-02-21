using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int _enemies;
    [SerializeField] private UnityEvent _enemyHasDrawnCloser;

    public void Decrease()
    {
        _enemies--;
        if (_enemies == 0)
        {
            _enemyHasDrawnCloser?.Invoke();
        }
    }
}
