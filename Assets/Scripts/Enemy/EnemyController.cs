using System;
using Units;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : CharacterController
    {
        public static event Action<int> OnDeath;

        protected override void Reset()
        {
            base.Reset();
            Type = EntityType.Enemy;
        }

        private void OnEnable()
        {
            healthController.OnDeath += CallSubscribers;
        }

        private void OnDisable()
        {
            healthController.OnDeath -= CallSubscribers;
        }

        private void CallSubscribers(int value)
        {
            OnDeath?.Invoke(25);
            
        }
    }
}