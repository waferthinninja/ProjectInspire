using System.Collections;
using System.Collections.Generic;
using Inspire;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandPointManager : MonoBehaviour {
	
	private int _commandPoints;
	[SerializeField] private int _commandPointsPerTurn;
	[SerializeField] private int _maxCommandPoints;

	public TextMeshProUGUI CommandPointsDisplay;
	
	// Update is called once per frame
	void Update () 
	{
		// debug - keys to change CommandPoints
		if (Input.GetKeyDown(KeyCode.LeftBracket))
		{
			AlterCommandPoints(1);
		}

		if (Input.GetKeyDown(KeyCode.RightBracket))
		{
			AlterCommandPoints(-1);
		}

		CommandPointsDisplay.text = string.Format(@"Command: {0} ({1}/turn, Max:{2})", _commandPoints, _commandPointsPerTurn, _maxCommandPoints);
	}

	public void Initialise(int commandPointsPerTurn, int maxCommandPoints)
	{
		_maxCommandPoints = maxCommandPoints;
		_commandPointsPerTurn = commandPointsPerTurn;
		SetCommandPoints(_commandPointsPerTurn);
		
	}

	public int GetCommandPoints()
	{
		return _commandPoints;
	}

	public bool TrySpendCommandPoints(int amount)
	{
		if (_commandPoints >= amount)
		{
			AlterCommandPoints(-amount);
			return true;
		}

		return false;
	}
	
	public void AlterCommandPoints(int amount)
	{
		_commandPoints = (_commandPoints + amount).Clamp(0, _maxCommandPoints);
		
	}

	public void SetCommandPoints(int level)
	{
		_commandPoints = level.Clamp(0, _maxCommandPoints);
	}

	public void AddPerTUrnPoints()
	{
		AlterCommandPoints(_commandPointsPerTurn);
	}
}
