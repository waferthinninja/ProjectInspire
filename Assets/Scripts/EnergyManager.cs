using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
	private int _energy;

	public Text EnergyDisplay;
	
	// Use this for initialization
	void Start ()
	{
		SetEnergy(3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// debug - keys to change energy
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			AlterEnergy(1);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			AlterEnergy(-1);
		}

		EnergyDisplay.text = string.Format(@"Energy: {0}", _energy);
	}

	public int GetEnergy()
	{
		return _energy;
	}

	public void AlterEnergy(int amount)
	{
		_energy += amount;
		ClampToPositive();
	}

	private void ClampToPositive()
	{
		if (_energy < 0)
		{
			_energy = 0;
		}
	}

	public void SetEnergy(int level)
	{
		_energy = level;
		ClampToPositive();
	}
}
