using UnityEngine;

namespace Inspire
{
    public abstract class GameEffect : MonoBehaviour
    {
        private GameEffectType Type;
        
        public abstract void DoEffect();
    }
}