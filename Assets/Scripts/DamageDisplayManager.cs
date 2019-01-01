using System.Collections;
using System.Collections.Generic;
using Inspire.Components;
using TMPro;
using UnityEngine;

public class DamageDisplayManager : MonoBehaviour
{
	
	private Damageable _target; // the object we want to track and display the damage of
	private TextMeshPro _text;

    // Start is called before the first frame update
    void Start()
    {
	    _text = GetComponent<TextMeshPro>();
	    
        // look for target in the parent object
		_target = GetComponentInParent<Damageable>();

		// if not present display error
	    if (_target == null)
	    {
		    Debug.LogError("Damageable component not found in parent");
		    _text.text = "Error";
	    }
		
    }

    // Update is called once per frame
    void Update()
    {
	    _text.text = _target.GetCurrentHealth() + "/" + _target.GetMaximumHealth();
    }
}
