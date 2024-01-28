using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    enum State {Patrol, Chase};

    [SerializeField] private Transform[] _waypoints;

    private NavMeshAgent _navMeshAgent;
    private int _waypointIndex = 0;

    private State _state = State.Patrol;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        transform.position = _waypoints[_waypointIndex].transform.position;
    }

    void FixedUpdate()
    {
        switch (_state)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
        }
    }

    void Patrol()
    {
        float distanceToDestination = _navMeshAgent.remainingDistance;
        if (distanceToDestination < 0.3f)
        {
            ChangeWaypointToNext();
        }

        _navMeshAgent.SetDestination( GetWaypointPosition() );
    }

    void Chase()
    {

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
