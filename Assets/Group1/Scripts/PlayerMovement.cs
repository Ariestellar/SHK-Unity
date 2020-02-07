using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;     

    private void Update()
    {
        Move();        
    }

    public void IncreaseSpeed()
    {
        _speed *= 2;               
    }

    public void SlowDown(int numberAccelerations)
    {
        _speed /= 2*numberAccelerations;
    }

    public void Stop()
    {
        _speed = 0;
    }

    private void Move()
    {
        transform.Translate(GetAxisMovement(Input.GetAxis("Horizontal")), GetAxisMovement(Input.GetAxis("Vertical")), 0);
    }

    private float GetAxisMovement(float axisDirection)
    {
        return axisDirection * _speed *Time.deltaTime;
    }
}
