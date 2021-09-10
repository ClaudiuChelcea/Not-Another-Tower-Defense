using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICanDetect
{
    List<EntityType> Priorities { get; }

    float AwarenessRange { get; }

    void LookAround();
}