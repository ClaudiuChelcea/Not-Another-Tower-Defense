using UnityEngine;

public class EntityController : MonoBehaviour
{
    private EntityType type;

    public EntityType Type
    {
        get => type;
        protected set => type = value;
    }
}