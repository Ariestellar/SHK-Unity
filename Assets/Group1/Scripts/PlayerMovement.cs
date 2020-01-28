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

    public void SlowDown()
    {
        _speed /= 2;
    }

    public void Stop()
    {
        _speed = 0;
    }

    private void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0);        
    }    
}
