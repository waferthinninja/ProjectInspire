using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

namespace Inspire
{
	// responsible for keeping track of the cards in a pile, shuffling and serving them up
	public class DeckManager : MonoBehaviour
	{
		private HandManager HandManager;

		private void Start()
		{
			HandManager = FindObjectOfType<HandManager>();
			
		}

		private void Update()
		{
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
				card.transform.SetParent(HandManager.transform);
			}

		}
	}
}