using UnityEngine;

namespace Inspire
{
    public class DiscardManager : MonoBehaviour
    {
        private DeckManager _deckManager;

        private void Awake()
        {
            _deckManager = FindObjectOfType<DeckManager>();
        }

        public void ReshuffleDiscardIntoDeck()
        {
            Card[] cards = GetComponentsInChildren<Card>();
            foreach (var card in cards)
            {
                card.transform.SetParent(_deckManager.transform);
                _deckManager.ShuffleCards();
            }
        }
    }
}