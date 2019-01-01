using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyLayoutManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// as with many things in this project, doing this every frame 
		// is inefficient but will be fine for now
		Enemy[] enemies = GetComponentsInChildren<Enemy>();
		for (int i = 0; i < enemies.Length; i++)
		{
			// for now just arrange in a line
			enemies[i].transform.localPosition = new Vector3(0, i * -9, 0);
		}
		
	}
}
