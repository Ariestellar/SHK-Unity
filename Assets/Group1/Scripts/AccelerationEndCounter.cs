using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AccelerationEndCounter : MonoBehaviour
{
    [SerializeField] private Timer _timerTemp;
    [SerializeField] private float _bonusExpirationTime;  
    [SerializeField] private UnityEvent _timerOver;
    
    public void LaunchTimer()
    {
        Timer timer = Instantiate(_timerTemp);
        timer.StartTimer(_bonusExpirationTime, _timerOver);
    }
}
