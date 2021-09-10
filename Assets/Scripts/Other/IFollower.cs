using UnityEngine;

public interface IFollower
{
    Transform Target { get; }

    float Speed { get; }

    float StoppingDistance { get; }

    void SetTarget(Transform newTarget);
}