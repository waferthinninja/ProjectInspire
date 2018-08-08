using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
	private int Energy;

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

		EnergyDisplay.text = string.Format(@"Energy: {0}", Energy);
	}

	public int GetEnergy()
	{
		return Energy;
	}

	public void AlterEnergy(int amount)
	{
		Energy += amount;
		ClampToPositive();
	}

	private void ClampToPositive()
	{
		if (Energy < 0)
		{
			Energy = 0;
		}
	}

	public void SetEnergy(int level)
	{
		Energy = level;
		ClampToPositive();
	}
}
