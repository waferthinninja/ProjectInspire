using Inspire.Components;
using UnityEngine;

namespace Inspire
{
    public class BasicDamageEffect : DamageableTargetEffect
    {
        [SerializeField] private int Damage;

        public BasicDamageEffect(int damage)
        {
            Damage = damage;
        }
        
        public override void DoEffect()
        {
            TargetManager targetManager = FindObjectOfType<TargetManager>();
            targetManager.GetTarget().GetComponentInParent<Damageable>().ApplyDamage(Damage);
        }
    }
}