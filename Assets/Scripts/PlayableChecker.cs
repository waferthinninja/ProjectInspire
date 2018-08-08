using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class PlayableChecker : MonoBehaviour
{

	private Card _card;
	private EnergyManager _energyManager;
	private SpriteRenderer _renderer;
	private GamePhaseManager _gamePhaseManager;
	
	// Use this for initialization
	void Start ()
	{
		_card = GetComponent<Card>();
		_energyManager = FindObjectOfType<EnergyManager>();
		_renderer = GetComponent<SpriteRenderer>();
		_gamePhaseManager = FindObjectOfType<GamePhaseManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool playable = false;
		// almost certainly dont need to do every frame, only certain events will change this, but for now...
		if (_gamePhaseManager.GamePhase == GamePhase.PlayerTurn)
		{
			if (_card.GetCost() <= _energyManager.GetEnergy())
			{
				playable = true;
			}
		}

		if (playable)
		{
			SetPlayable();
		}
		else
		{
			SetUnplayable();
		}
	}

	private void SetPlayable()
	{
		_renderer.color = Color.green;
	}

	private void SetUnplayable()
	{
		
		_renderer.color = Color.red;
	}
}
