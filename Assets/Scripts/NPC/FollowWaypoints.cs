using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private NavMeshAgent _navMeshAgent;
    private int _waypointIndex = 0;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    void FixedUpdate()
    {
        if (_navMeshAgent.remainingDistance < 0.3f)
        {
            ChangeWaypointToNext();
        }
        _navMeshAgent.SetDestination( GetWaypointPosition() );
    }

    void ChangeWaypointToNext()
    {
        _waypointIndex = (_waypointIndex + 1) % _waypoints.Length;
    }

    Vector3 GetWaypointPosition()
    {
        return _waypoints[_waypointIndex].position;
    }
}