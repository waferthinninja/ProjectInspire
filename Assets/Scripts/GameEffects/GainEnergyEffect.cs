using UnityEngine;

namespace Inspire
{
    public class GainEnergyEffect : GameEffect
    {
        [SerializeField] private int Amount;
        
        public override void DoEffect()
        {
            FindObjectOfType<EnergyManager>().ChangeEnergy(Amount);
        }
    }
}