using UnityEngine;

namespace Inspire
{
    public class CardPile : MonoBehaviour
    {
        public int GetCardCount()
        {
            Card[] cards = GetComponentsInChildren<Card>();
            return cards.Length;
        }
    }
}