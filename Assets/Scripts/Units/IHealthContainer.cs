using System;

namespace Units
{
    public interface IHealthContainer
    {
        float MaxHealth { get; }
        float Health { get; }

        void TakeDamage(float amount);
        void Heal(float amount);
        void Die();
    }
}