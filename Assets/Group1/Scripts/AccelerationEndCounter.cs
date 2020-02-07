using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class AccelerationEndCounter : MonoBehaviour
{   
    [SerializeField] private float _time;
    [SerializeField] private int _accelerationBonusCounter;    

    private void Update()
    {
        CountTime();
    }

    public void LaunchTimer()
    {
        _accelerationBonusCounter += 1;
        _time = 2;
    }

    private void CountTime()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;                   
        }
        else if(_time < 0)
        {
            GetComponent<PlayerMovement>().SlowDown(_accelerationBonusCounter);
            _time = 0;
            _accelerationBonusCounter = 0;
        }
    }
}
