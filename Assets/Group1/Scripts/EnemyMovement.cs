using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 _nextPosition;

    private void Start()
    {
        _nextPosition = Random.insideUnitCircle * 4;
    }

    private void Update()
    {
        FindRandomWay();
    }

    private void FindRandomWay()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, 2 * Time.deltaTime);
        if (transform.position == _nextPosition)
        {
            _nextPosition = Random.insideUnitCircle * 4;
        }
    }
}
