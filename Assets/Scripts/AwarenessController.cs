using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AwarenessController : MonoBehaviour, ICanDetect
{
    [SerializeField] private float awarenessRange = 5f;
    [SerializeField] private List<EntityType> priorities;

    public List<EntityType> Priorities
    {
        get => priorities;
        protected set
        {
            priorities.Clear();
            priorities.AddRange(value);
        }
    }

    public float AwarenessRange => awarenessRange;

    public event Action<EntityController> OnTargetSpotted;


    private void Reset()
    {
        Priorities = new List<EntityType>() {EntityType.Objective, EntityType.Unit,};
    }

    public void LookAround()
    {
        foreach (var type in priorities)
        {
            var nearbyTargets = FindObjectsOfType<EntityController>()
                .Where(entity => entity.Type == type).Where(objective =>
                    Vector3.Distance(objective.transform.position, transform.position) <
                    AwarenessRange).ToArray();

            if (nearbyTargets.Length > 0)
            {
                var detectedTarget = nearbyTargets
                    .OrderBy(entity => Vector3.Distance(entity.transform.position, transform.position)).ToArray()[0];

                OnTargetSpotted?.Invoke(detectedTarget);

                break;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(LookAround), 0f, 0.5f);
    }
}