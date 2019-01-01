using System;
using UnityEngine;

namespace Inspire.Components
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private int MaxHealth;
        private int CurrentHealth = 0;

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void ChangeHealth(int delta)
        {
            CurrentHealth = (CurrentHealth + delta).Clamp(0, MaxHealth);
        }
        
        public int GetMaximumHealth()
        {
            return MaxHealth;
        }

        public int GetCurrentHealth()
        {
            return CurrentHealth;
        }
    }
}