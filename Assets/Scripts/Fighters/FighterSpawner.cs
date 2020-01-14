using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSpawner : MonoBehaviour
{
	private CommandPointManager _commandPointManager;
	
	public Fighter FighterPrefab;
	public Transform FighterContainer;
	
	// Use this for initialization
	private void Awake()
	{
		_commandPointManager = FindObjectOfType<CommandPointManager>();
	}

	
	// Update is called once per frame
	void Update () 
	{
		
		
		
	}

	private void OnMouseUpAsButton()
	{
		if (_commandPointManager.TrySpendCommandPoints(FighterPrefab.Cost))
		{
			var go = Instantiate(FighterPrefab);
			go.transform.SetParent(FighterContainer);
		}
	}
}
