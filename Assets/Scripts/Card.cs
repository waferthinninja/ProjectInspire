using System.Collections.Generic;
using UnityEngine;

namespace Inspire
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private string Name;
        [SerializeField] private CardType Type;
        [SerializeField] private TargetType TargetType;
        [SerializeField] private GameEffect OnPlayEffect;
        [SerializeField] private int BaseCost;
        [SerializeField] private string CardText;// this will probably need to be provided by a function eventually  

        private CardMovementManager _movementManager;
        
        private void Awake()
        {
            _movementManager = GetComponent<CardMovementManager>();
        }

        public string GetName()
        {
            return Name;
        }

        public int GetCost()
        {
            return BaseCost;
        }

        public TargetType GetTargetType()
        {
            return TargetType;
        }
        
        public string GetText()
        {
            // do manipulations here e.g. when card is being played, substitute symbols "1/laser fighter" with actual
            return CardText;
        }

        public CardMovementManager GetMovementManager()
        {
            return _movementManager;
        }

        public void Play()
        {
            OnPlayEffect.DoEffect();
        }
    }
}