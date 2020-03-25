using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AccelerationEndCounter))]
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
        var delta = GetMovementDelta(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(delta);
    }   

    private Vector3 GetMovementDelta(float xInput, float yInput)
    {
        return new Vector3(xInput, yInput, 0) * _speed * Time.deltaTime;
    }
}
