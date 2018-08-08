using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour {

	public GamePhase GamePhase { get; private set; }
	
	void Start ()
	{
		GamePhase = GamePhase.PlayerTurn;
	}
	
}
