using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceNextPoint;

    private Vector3 _nextPosition;

    private void Update()
    {
        FindRandomWay();
    }

    private void FindRandomWay()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * Time.deltaTime);
        if (transform.position == _nextPosition)
        {
            _nextPosition = Random.insideUnitCircle * _distanceNextPoint;
        }
    }
}
