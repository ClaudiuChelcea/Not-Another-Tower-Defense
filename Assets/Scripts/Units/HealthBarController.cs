using System;
using UnityEngine;
using UnityEngine.UI;

namespace Units
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        public float Value
        {
            get => healthSlider.value;
            set
            {
                if (healthSlider == null)
                {
                    healthSlider = GetComponentInChildren<Slider>();
                }

                healthSlider.value = value;
            }
        }

        private void Reset()
        {
            healthSlider ??= GetComponentInChildren<Slider>();
        }

        private void Start()
        {
            Reset();
        }
    }
}