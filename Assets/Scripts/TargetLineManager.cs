using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using Inspire;
using UnityEngine;

public class TargetLineManager : MonoBehaviour
{
	private TargetManager _targetManager;
	private HandManager _handManager;
	private LineRenderer _lineRenderer;
	
	// Use this for initialization
	void Awake ()
	{
		_targetManager = FindObjectOfType<TargetManager>();
		_handManager = FindObjectOfType<HandManager>();
		_lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_targetManager.TargetingModeActive)
		{
			PotentialTarget target = _targetManager.GetTarget();
			Card card = _handManager.GetSelectedCard();
			
			Vector3[] positions = new Vector3[2];
			positions[0] = card.transform.position;
			positions[1] = GetCurrentMousePosition();

			_lineRenderer.SetPositions(positions);

			if (target != null)
			{
				_lineRenderer.endColor = Color.green;
			}
			else
			{
				_lineRenderer.endColor = Color.red;
			}
		}
	}

	public void ClearLine()
	{
		_lineRenderer.SetPositions(new Vector3[2]);
	}
	
	private Vector3 GetCurrentMousePosition()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		var plane = new Plane(Vector3.forward, Vector3.zero);
 
		float rayDistance;
		if (plane.Raycast(ray, out rayDistance))
		{
			return ray.GetPoint(rayDistance);
             
		}
 
		return new Vector3();
	}
}
