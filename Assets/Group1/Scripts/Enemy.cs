using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private event DeathHandler _deathing;

    public delegate void DeathHandler(Enemy enemy);    
    public event DeathHandler Deathing 
    {
        add => _deathing += value;
        remove => _deathing -= value;
    }

    public void Death(Enemy enemy)
    {
        _deathing?.Invoke(enemy);
        Destroy(gameObject);
    }
}
