using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	private HandManager _handManager;
	private TargetLineManager _targetLineManager;
	
	private PotentialTarget _target;

	public bool TargetingModeActive { get; private set; }
	
	// Use this for initialization
	void Awake ()
	{
		_handManager = FindObjectOfType<HandManager>();
		_targetLineManager = FindObjectOfType<TargetLineManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateTargetingMode()
	{
		TargetingModeActive = true;
	}

	public void DeactivateTargetingMode()
	{
		TargetingModeActive = false;
		_targetLineManager.ClearLine();
	}

	public PotentialTarget GetTarget()
	{
		return _target;
	}
	
	public bool CheckTarget(PotentialTarget target)
	{
		if (_handManager.GetSelectedCard() == null) return false;
		if (!TargetingModeActive) return false;

		// logic for whether target is valid will go here
		_target = target;
		return true;
	}

	public void ClearTarget()
	{
		_target = null;
	}
}
