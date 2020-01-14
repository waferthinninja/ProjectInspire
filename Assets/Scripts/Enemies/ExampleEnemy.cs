using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Inspire
{
    public class ExampleEnemy : Enemy
    {
        public override void PickNextAction()
        {
            _actions = new List<GameEffect>();

            int choice = Random.Range(0, 2);

            switch (choice)
            {
                 case 0:
                     Debug.Log("Target Carrier");
                     var basicCarrierDamage = gameObject.AddComponent<BasicCarrierDamage>();
                     basicCarrierDamage.Damage = 5;
                     _actions.Add(basicCarrierDamage);
                     break;
                 case 1:
                     Debug.Log("Target Fighters");
                     var fighterAttack = gameObject.AddComponent<BasicRandomFighterAttack>();
                     fighterAttack.Damage = 2;
                     _actions.Add(fighterAttack);
                     break;
                 default:
                     Debug.Log("Bad choice - scripting error");
                     break;
            }
        }
    }
}