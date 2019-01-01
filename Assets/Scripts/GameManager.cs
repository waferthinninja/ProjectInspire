using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private DeckManager _deckManager;
	
	private int _cardDrawPerTurn = 6; // probably move these to a player manager
	
	public GamePhase GamePhase { get; private set; }
	
	void Awake ()
	{
		_deckManager = FindObjectOfType<DeckManager>();
		GamePhase = GamePhase.Setup;
		
		StartCoroutine("StartPlayerTurn");
	}

	void Update()
	{

	}

	private IEnumerator StartPlayerTurn()
	{
		yield return null;
		
		// prob turn this into a coroutine to dish cards out over the course of half a second rather than instantly?
		for (int i = 0; i < _cardDrawPerTurn; i++)
		{
			_deckManager.DrawCard();
			yield return new WaitForSeconds(0.25f);
		}
		
		GamePhase = GamePhase.PlayerTurn;

		yield return null;
	}
	
}
