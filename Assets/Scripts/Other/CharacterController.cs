using System;
using Units;
using UnityEngine;

[RequireComponent(typeof(HealthController))]
public class CharacterController : EntityController
{
    [SerializeField] protected HealthController healthController;

    protected virtual void Reset()
    {
        healthController ??= GetComponent<HealthController>();
    }

    private void Start()
    {
        Reset();
    }
}