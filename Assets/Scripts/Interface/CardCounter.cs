using TMPro;
using UnityEngine;

namespace Inspire
{
    public class CardCounter : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        [SerializeField] private CardPile _cardPile;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _text.text = _cardPile.GetCardCount().ToString();
        }
    }
}