﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		}
		
		private void SetTargetPositions()
		{
			Vector2 center = new Vector2(transform.position.x, transform.position.y - (int)Radius);
	
			for (int i = 0; i < _cards.Length; i++)
			{
				_cards[i].SetPositionInfo(transform.position.x + (Radius * Mathf.Sin(_angles[i] * Mathf.Deg2Rad)),
				                            center.y + (Radius * Mathf.Cos(_angles[i] * Mathf.Deg2Rad)),
					                        -_angles[i],
											i);
				
			}

		}
	}

}