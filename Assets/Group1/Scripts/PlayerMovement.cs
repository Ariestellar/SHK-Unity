using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private DeathCounter _deathCounter;
    
    private bool _timer;
    private float _time;

    private void Awake()
    {
        _deathCounter.OnAllEnemiesDead += () => StopGame();
    }

    private void Update()
    {
        СontrolMovement();
        LaunchAcceleration();
    }

    public void IncreaseSpeed()
    {
        _speed *= 2;
        _timer = true;
        _time = 2;
    }

    private void СontrolMovement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void LaunchAcceleration()
    {
        if (_timer)
        {
            _time -= Time.deltaTime;
            if (_time < 0)
            {
                _timer = false;
                _speed /= 2;
            }
        }
    }   

    private void StopGame()
    {
        Time.timeScale = 0;
    }
}
