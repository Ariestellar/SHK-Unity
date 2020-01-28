using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyDeath;
       
    public void Death()
    {
        _enemyDeath.Invoke();
        _enemyDeath.RemoveAllListeners();
        Destroy(gameObject);
    }
}
