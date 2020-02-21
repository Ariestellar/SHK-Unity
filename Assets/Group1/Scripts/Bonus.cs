using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : ObjectsToCapture
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AccelerationEndCounter _accelerationEndCounter;

    public override void Catch()
    {
        _playerMovement.IncreaseSpeed();
        _accelerationEndCounter.LaunchTimer();
        Destruction();
    }
}
