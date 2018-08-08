using System.Collections;
using System.Collections.Generic;
using Inspire;
using TMPro;
using UnityEngine;

public class CostDisplayManager : MonoBehaviour
{
	private Card _card;
	private TextMeshPro _text;
	
	// Use this for initialization
	void Start ()
	{
		_card = GetComponentInParent<Card>();
		_text = GetComponent<TextMeshPro>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// prob dont need to do this in update, only when certain events happen
		_text.text = _card.GetCost().ToString();
	}
}
