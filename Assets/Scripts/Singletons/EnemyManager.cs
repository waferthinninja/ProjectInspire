using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inspire
{
	[ExecuteInEditMode]
	public class EnemyManager : MonoBehaviour
	{
	
		public IEnumerator ProcessEnemyActions()
		{
			Debug.Log("Processing enemy actions");
			Enemy[] enemies = GetComponentsInChildren<Enemy>();

			for (int i = 0; i < enemies.Length; i++)
			{
				enemies[i].ProcessActions();

				yield return new WaitForSeconds(3f);
			}
			
			PickNextActions();

			yield return null;
		}
		
		public void PickNextActions()
		{
			Debug.Log("Picking new enemy actions");
			
			Enemy[] enemies = GetComponentsInChildren<Enemy>();
			
			for (int i = 0; i < enemies.Length; i++)
			{
				enemies[i].PickNextAction();
			}			
		}
		
		// Update is called once per frame
		void Update()
		{
			// as with many things in this project, doing this every frame 
			// is inefficient but will be fine for now
			Enemy[] enemies = GetComponentsInChildren<Enemy>();
			for (int i = 0; i < enemies.Length; i++)
			{
				Enemy enemy = enemies[i];
				
				// for now just arrange in a line
				enemy.transform.localPosition = new Vector3(0, i * -9, 0);
			}

		}
	}
}