using System;
using UnityEngine;

namespace Inspire.Components
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private int MaxHealth;
        [SerializeField] private int MaxShield = 999; 
        private int _currentHealth = 0;
        private int _currentShield = 0;

        private void Start()
        {
            _currentHealth = MaxHealth;
        }

        
        public void ApplyDamage(int damage)
        {
            ApplyDamage(damage, false);
        }
        
        public void ApplyDamage(int damage, bool ignoreShield)
        {
            if (ignoreShield)
            {
                ChangeHealth(-damage);
            }
            else
            {
                int remaining = DamageShield(damage);
                if (remaining > 0)
                {
                    ChangeHealth(-remaining);
                }
            }
        }
        
        public int DamageShield(int damage)
        {
            int remaining = (damage - _currentShield).Clamp(0, damage);
            _currentShield = (_currentShield - damage).Clamp(0, MaxShield);
            return remaining;
        }
        
        public void ChangeShield(int delta)
        {
            _currentShield = (_currentShield + delta).Clamp(0, MaxShield);
           
        }
        
        public void ChangeHealth(int delta)
        {
            _currentHealth = (_currentHealth + delta).Clamp(0, MaxHealth);
            if (_currentHealth == 0)
            {
                Die();
            }
        }

        public int GetMaximumHealth()
        {
            return MaxHealth;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
        
        public int GetCurrentShield()
        {
            return _currentShield;
        }
        
        private void Die()
        {
            Destroy(this.gameObject);
        }
    }
}