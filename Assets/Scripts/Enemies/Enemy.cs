using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

namespace Inspire
{
	public class Enemy : MonoBehaviour
	{
		protected List<GameEffect> _actions;

		public void ProcessActions()
		{
			foreach (GameEffect action in _actions)
			{
				action.DoEffect();
			}
		}

		public virtual void PickNextAction()
		{
		}
	}
}
