using TMPro;
using UnityEngine;

namespace Inspire
{
    public class CardNameDisplayManager : MonoBehaviour
    {
        private Card _card;
		private TextMeshPro _text;
		
		void Awake ()
		{
			_card = GetComponentInParent<Card>();
			_text = GetComponent<TextMeshPro>();
		}

	    void Update()
	    {
		    _text.text = _card.GetName();
	    }
    }
}