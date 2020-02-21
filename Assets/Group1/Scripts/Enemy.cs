using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : ObjectsToCapture
{
    [SerializeField] private EnemyCounter _enemyCounter;

    public override void Catch()
    {
        _enemyCounter.Decrease();
        Destruction();
    }
}
