using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusNextPoint;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = GetRandomTargetPosition(_radiusNextPoint);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {            
            _targetPosition = GetRandomTargetPosition(_radiusNextPoint);
        }
    }

    private Vector3 GetRandomTargetPosition(float radius)
    { 
        return Random.insideUnitCircle * radius;
    }
}
