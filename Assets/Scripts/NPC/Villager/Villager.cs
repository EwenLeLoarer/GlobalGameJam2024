using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public bool IsLaughing;

    [SerializeField] float _laughtingTime = 7f;
    private float _laughTimer;

    void Awake()
    {
        IsLaughing = false;
    }

    void FixedUpdate()
    {
        if (IsLaughing)
        {
            _laughTimer -= Time.fixedDeltaTime;
            if (_laughTimer <= 0f)
            {
                IsLaughing = false;
            }
        }
    }

    void FallOnBanana()
    {
        var colliders = Physics.OverlapSphere(transform.position, 10f, Layers.NPCLayerMask);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Villager villager))
            {
                if (villager == this) continue;
                villager.StartLaughing();
            }
        }
    }

    public void StartLaughing()
    {
        _laughTimer = _laughtingTime;
    }
}