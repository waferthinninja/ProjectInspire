using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPointManager : MonoBehaviour {
	
	private int _commandPoints;

	public Text CommandPointsDisplay;
	
	// Use this for initialization
	void Start ()
	{
		SetCommandPoints(3);
	}
	
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

		CommandPointsDisplay.text = string.Format(@"Command: {0}", _commandPoints);
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
		_commandPoints += amount;
		ClampToPositive();
	}

	private void ClampToPositive()
	{
		if (_commandPoints < 0)
		{
			_commandPoints = 0;
		}
	}

	public void SetCommandPoints(int level)
	{
		_commandPoints = level;
		ClampToPositive();
	}
}
