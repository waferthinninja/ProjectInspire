using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _enabled;
    private SpriteRenderer _renderer;
    
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        EnableButton();
    }
    
    private void OnMouseUpAsButton()
    {
        if (_enabled)
        {
            StartCoroutine(DoEndTurn());
        }
    }

    private IEnumerator DoEndTurn()
    {
        DisableButton();
        
        Debug.Log("Processing end of turn");
        yield return StartCoroutine(_gameManager.EndTUrn());
        
        yield return null;
        EnableButton();
        yield return null;
    }
    
    private void DisableButton()
    {
        _renderer.color = Color.red;
        Debug.Log("Disabling end turn button");
        _enabled = false;
    }

    private void EnableButton()
    {
        _renderer.color = Color.green;
        Debug.Log("Enabling end turn button");
        _enabled = true;
    }
}
