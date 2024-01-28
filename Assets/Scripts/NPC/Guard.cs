using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    enum State {Patrol, Chase, ArrestVillager};

    [SerializeField] private Transform[] _waypoints;

    private NavMeshAgent _navMeshAgent;
    private int _waypointIndex = 0;

    private State _state = State.Patrol;

    private GameObject _villagerTarget = null;

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
            case State.ArrestVillager:
                ArrestVillager();
                break;
        }
    }

    void Patrol()
    {
        if (_navMeshAgent.remainingDistance < 0.3f)
        {
            ChangeWaypointToNext();
        }
        _navMeshAgent.SetDestination( GetWaypointPosition() );

        /* detect laughing villager */
        var colliders = Physics.OverlapSphere(transform.position, 50f, Layers.NPCLayerMask);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Villager villager))
            {
                if (villager.IsLaughing)
                {
                    _villagerTarget = villager.gameObject;
                    _state = State.ArrestVillager;
                    return;
                }
            }
        }
    }

    void Chase()
    {

    }

    void ArrestVillager()
    {
        _navMeshAgent.SetDestination( _villagerTarget.transform.position );
        if (_navMeshAgent.remainingDistance < 1f)
        {
            Destroy(_villagerTarget);
            _state = State.Patrol;
        }
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
