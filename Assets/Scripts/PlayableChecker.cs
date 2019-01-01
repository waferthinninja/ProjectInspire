using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class PlayableChecker : MonoBehaviour
{

	private Card _card;
	private EnergyManager _energyManager;
	private SpriteRenderer _renderer;
	private GameManager _gamePhaseManager;
	
	// Use this for initialization
	void Start ()
	{
		_card = GetComponent<Card>();
		_energyManager = FindObjectOfType<EnergyManager>();
		_renderer = GetComponent<SpriteRenderer>();
		_gamePhaseManager = FindObjectOfType<GameManager>();
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
		_renderer.color = new Color(0.8f,0.9f,0.8f);
	}

	private void SetUnplayable()
	{
		
		_renderer.color = new Color(0.8f,0.7f,0.7f);
	}
}
