using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inspire
{
	// responsible for keeping track of the cards in a pile, shuffling and serving them up
	public class DeckManager : MonoBehaviour
	{
		private HandManager _handManager;
		private DiscardManager _discardManager;
		
		private void Awake()
		{
			_handManager = FindObjectOfType<HandManager>();
			_discardManager = FindObjectOfType<DiscardManager>();
		}
		
		private void Update()
		{
			// debug code to draw cards
			if (Input.GetKeyDown(KeyCode.D))
			{
				DrawCard();
			}
		}
		
		public void DrawCard()
		{
			Card card = GetComponentInChildren<Card>();
			
			if (card != null)
			{
				card.GetComponent<VisibilityManager>().Show();
				card.transform.SetParent(_handManager.transform);
			}
			else
			{
				if (_discardManager.GetComponent<CardPile>().GetCardCount() > 0)
				{
					_discardManager.ReshuffleDiscardIntoDeck();
					DrawCard();
				}
			}

		}

		public void ShuffleCards()
		{
			// possibly horrible?
			Card[] cards = GetComponentsInChildren<Card>();
			for (int i = 0; i < cards.Length; i++)
			{
				cards[i].transform.SetSiblingIndex(Random.Range(0, cards.Length)); 
			}
		}
	}
}