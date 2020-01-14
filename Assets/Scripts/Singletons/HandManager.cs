using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Inspire
{
	public class HandManager : MonoBehaviour
	{
		private Card[] _cards;
		private float[] _angles;
		private int _selectedIndex;
		
		public float PreferredAngle;
		public float TotalAngle;
		public float Radius;

		private void Start()
		{
			_selectedIndex = -999;
		}
		
		private void Update()
		{
			// should prob only do this when something changes, but for now...
			_cards = GetComponentsInChildren<Card>();
			CalculateCardAngles();
			SetTargetPositions();
		}
		
		private void CalculateCardAngles()
		{
			if (_cards.Length < 1)
			{
				return;
			}

			_angles = new float[_cards.Length];

			// if cards can be at preferred angle without using full total angle
			// they will sit nicely
			float angleBetweenCards = 0;
			if ((_cards.Length - 1) * PreferredAngle <= TotalAngle)
			{
				angleBetweenCards = PreferredAngle;
			}
			else
			{
				// too many cards for preferred angle, divide space evenly
				angleBetweenCards = TotalAngle / (_cards.Length - 1);
			}

			if (_cards.Length % 2 == 1) // odd
			{
				// one card at 0, then remainder split to either side
				_angles[_cards.Length / 2] = 0;
				for (int i = 1; i <= _cards.Length / 2; i++)
				{
					_angles[(_cards.Length / 2) + i] = angleBetweenCards * i;
					_angles[(_cards.Length / 2) - i] = -angleBetweenCards * i;
				}
			}
			else // even
			{
				for (int i = 0; i < _cards.Length / 2; i++)
				{
					_angles[(_cards.Length / 2) + i] = (angleBetweenCards / 2) + angleBetweenCards * i;
					_angles[(_cards.Length / 2) - (i + 1)] = -(angleBetweenCards / 2) - angleBetweenCards * i;
				}
			}
			
			// if a card is selected, move adjacent cards a bit
			if (_selectedIndex > 0)
			{
				_angles[_selectedIndex - 1] -= PreferredAngle / 4f;
			}

			if (_selectedIndex >= 0 && _selectedIndex < _cards.Length - 1)
			{
				_angles[_selectedIndex + 1] += PreferredAngle / 4f;
			}
			
			if (_selectedIndex > 1)
			{
				_angles[_selectedIndex - 2] -= PreferredAngle / 8f;
			}

			if (_selectedIndex >= 0 && _selectedIndex < _cards.Length - 2)
			{
				_angles[_selectedIndex + 2] += PreferredAngle / 8f;
			}
			
		}
		
		private void SetTargetPositions()
		{
			Vector2 center = new Vector2(transform.position.x, transform.position.y - (int)Radius);
	
			for (int i = 0; i < _cards.Length; i++)
			{
				_cards[i].GetMovementManager().SetPositionInfo(transform.position.x + (Radius * Mathf.Sin(_angles[i] * Mathf.Deg2Rad)),
				                            (_selectedIndex == i ? center.y + Radius + 0.5f : 
					                                               center.y + (Radius * Mathf.Cos(_angles[i] * Mathf.Deg2Rad))),
											(_selectedIndex == i ? 0 : -_angles[i]),
											i,
											_selectedIndex == i);
				
			}

		}

		public void SetSelected(int index)
		{
			_selectedIndex = index;
		}

		public void ClearSelected()
		{
			_selectedIndex = -999;
		}
		
		[CanBeNull]
		public Card GetSelectedCard()
		{
			if (_selectedIndex < 0) return null;

			return _cards[_selectedIndex];
		}

	}

}