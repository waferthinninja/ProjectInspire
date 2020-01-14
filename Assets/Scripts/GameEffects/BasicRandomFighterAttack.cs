using Inspire.Components;
using UnityEngine;

namespace Inspire
{
    public class BasicRandomFighterAttack : GameEffect
    {
        [SerializeField] public int Damage;
        
        public override void DoEffect()
        {
            Fighter[] fighters = FindObjectsOfType<Fighter>();

            if (fighters.Length == 0)
            {
                Debug.Log("No fighters to attack");
            }
            else
            {
                int index = Random.Range(0, fighters.Length);
                Debug.Log(string.Format("Dealing {0} damage to fighter {1}", Damage, index));
                fighters[index].GetComponent<Damageable>().ApplyDamage(Damage);
            }
        }
    }
}