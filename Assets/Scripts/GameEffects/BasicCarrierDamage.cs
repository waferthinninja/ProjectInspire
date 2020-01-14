using Inspire.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inspire
{
    public class BasicCarrierDamage : GameEffect
    {
        [SerializeField] public int Damage;
        
        public override void DoEffect()
        {
            Debug.Log(string.Format("Dealing {0} damage to Carrier", Damage));
            Carrier carrier = FindObjectOfType<Carrier>();
            carrier.GetComponent<Damageable>().ApplyDamage(Damage);
        }
    }
}