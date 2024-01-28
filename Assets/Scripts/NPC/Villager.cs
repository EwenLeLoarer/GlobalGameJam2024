using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public bool IsLaughing;

    [SerializeField] float _laughtingTime = 3f;
    private float _laughTimer;

    [SerializeField] SoundEffectSO _laughSE;

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

    public void FallOnBanana()
    {
        var colliders = Physics.OverlapSphere(transform.position, 20f, Layers.NPCLayerMask);
        print((colliders, colliders.Length));
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Villager villager))
            {
                if (villager.gameObject == this.gameObject) continue;
                villager.StartLaughing();
            }
        }
    }

    public void StartLaughing()
    {
        _laughTimer = _laughtingTime;
        IsLaughing = true;

        _laughSE.Play();
    }
}
