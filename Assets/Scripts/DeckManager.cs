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
		
		public TextMeshPro CardCounter;

		private void Awake()
		{
			_handManager = FindObjectOfType<HandManager>();
			

		}

		private void Update()
		{
			// should prob not do this here but for now
			CardCounter.sortingOrder = 2001;
			CardCounter.text = GetComponentsInChildren<Card>().Length.ToString();
			
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
				card.transform.SetParent(_handManager.transform);
			}

		}
	}
}