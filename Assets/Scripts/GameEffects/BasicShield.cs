using Inspire.Components;
using UnityEngine;

namespace Inspire
{
    public class BasicShield : GameEffect
    {
        [SerializeField] public int Amount;
        
        public override void DoEffect()
        {
            
            TargetManager targetManager = FindObjectOfType<TargetManager>();
            Debug.Log(string.Format("Adding {0} shield to {1}", Amount, targetManager.GetTarget().name));
            targetManager.GetTarget().GetComponentInParent<Damageable>().ChangeShield(Amount);
        }
    }
}