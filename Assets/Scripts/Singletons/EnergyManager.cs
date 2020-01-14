using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
	private int _energy;
	[SerializeField] private int _energyPerTurn;

	public TextMeshProUGUI EnergyDisplay;
	
	// Use this for initialization
	void Start ()
	{
	}

	void Initialise(int energyPerTurn)
	{
		_energyPerTurn = energyPerTurn;
		_energy = _energyPerTurn;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// debug - keys to change energy
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			ChangeEnergy(1);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			ChangeEnergy(-1);
		}

		EnergyDisplay.text = string.Format(@"Energy: {0}/{1}", _energy, _energyPerTurn);
	}

	public int GetEnergy()
	{
		return _energy;
	}

	public void ChangeEnergy(int amount)
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

	public void ResetEnergy()
	{
		_energy = _energyPerTurn;
	}
}
