using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private int _waypointIndex = 0;

    void Awake()
    {
        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    void Update()
    {



        // if(_pointIndex <= _points.Length - 1)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].transform.position, _moveSpeed * Time.deltaTime);

        //     if(transform.position == _points[_pointIndex].transform.position)
        //     {
        //         _pointIndex++;
        //     }
        // }
    }
}
