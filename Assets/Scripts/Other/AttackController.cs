using Units;
using UnityEngine;

[RequireComponent(typeof(AwarenessController))]
public class AttackController : MonoBehaviour, ICanAttack
{
    public float range = 2f;

    public float AttackRange
    {
        get => range;
        protected set => range = value;
    }

    public float Power { get; protected set; }

    public virtual void Attack(IHealthContainer target)
    {
        target.TakeDamage(Power);
    }
}
