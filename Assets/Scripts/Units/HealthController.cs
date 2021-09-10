using System;
using UnityEngine;

namespace Units
{
    public class HealthController : MonoBehaviour, IHealthContainer
    {
        [SerializeField] [Range(0f, 500f)] private float maxHealth = 100;
        [SerializeField] private float health;

        [SerializeField] private HealthBarController healthBar;

        public event Action<int> OnDeath;

        public float MaxHealth => maxHealth;

        public float Health
        {
            get => health;
            private set
            {
                health = value;
                if (healthBar != null)
                {
                    healthBar.Value = health / maxHealth;
                }
            }
        }

        private void OnValidate()
        {
            Health = MaxHealth;
        }

        private void Reset()
        {
            healthBar ??= GetComponentInChildren<HealthBarController>();
            healthBar.Value = 1;
        }

        private void Start()
        {
            Reset();
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0f)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            Health = Mathf.Max(MaxHealth, Health + amount);
        }

        [ContextMenu("TestDie")]
        public void Die()
        {
            OnDeath?.Invoke(gameObject.GetHashCode());
            Destroy(gameObject);
        }
    }
}