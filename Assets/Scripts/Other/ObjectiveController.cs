using System;

public class ObjectiveController : EntityController
{
    protected virtual void Reset()
    {
        Type = EntityType.Objective;
    }

    protected virtual void Start()
    {
        Reset();
    }
}