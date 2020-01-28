using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class TimerPlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _onTimer;

    private float _time;

    private void Update()
    {
        CountTime();
    }

    public void LaunchTimer()
    {
        _onTimer = true;
        _time = 2;
    }

    private void CountTime()
    {
        if (_onTimer)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _onTimer = false;                
                GetComponent<PlayerMovement>().SlowDown();
            }
        }
    }
}
