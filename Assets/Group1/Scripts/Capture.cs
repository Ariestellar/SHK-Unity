using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Capture : MonoBehaviour
{    
    [SerializeField] private List<Enemy> _enemyList;    
    [SerializeField] private UnityEvent _enemiesCaught;

    private int _numberEnimes;

    private void Start()
    {
        _numberEnimes = _enemyList.Count;
    }

    private void Update()
    {
        CatchEnemy();
    }

    public void CountCapturedEnemies()
    {
        _numberEnimes -= 1;
        if (_numberEnimes == 0)
        {
            _enemiesCaught.Invoke();
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }

    private void CatchEnemy()
    {
        for (int i = _enemyList.Count - 1; i >= 0; i--)
        {
            if (Vector3.Distance(transform.position, _enemyList[i].transform.position) < 0.2f)
            {
                _enemyList[i].Death();
            }
        }
    }    
}
