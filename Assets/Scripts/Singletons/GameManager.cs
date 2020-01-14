using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private DeckManager _deckManager;
	private EnemyManager _enemyManager;
	private EnergyManager _energyManager;
	private CommandPointManager _commandPointManager;
	
	[SerializeField] private int _cardDrawPerTurn; 
	
	public GamePhase GamePhase { get; private set; }
	
	void Awake ()
	{
		_deckManager = FindObjectOfType<DeckManager>();
		_enemyManager = FindObjectOfType<EnemyManager>();
		_energyManager = FindObjectOfType<EnergyManager>();
		_commandPointManager = FindObjectOfType<CommandPointManager>();
		GamePhase = GamePhase.Setup;
		StartTurn();
	}

	public void StartTurn()
	{
		StartCoroutine("StartPlayerTurn");
	}

	public IEnumerator EndTUrn()
	{
		yield return StartCoroutine(_enemyManager.ProcessEnemyActions());
		StartTurn();
		yield return null;
	}
	

	public IEnumerator StartPlayerTurn()
	{
		yield return null;
		_energyManager.ResetEnergy();
		_commandPointManager.AddPerTUrnPoints();		
		_enemyManager.PickNextActions();
		
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
