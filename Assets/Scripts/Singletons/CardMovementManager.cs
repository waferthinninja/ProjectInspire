using System.Collections;
using System.Collections.Generic;
using Inspire;
using TMPro;
using UnityEngine;

public class CardMovementManager : MonoBehaviour
{
    
    private Vector3 _targetPosition;
    private float _targetAngle;
    public float MovementSpeed = 5f;
    public float RotationSpeed = 1f;
    
    private int _index; // not sure if this is a good way, store position in hand
    // but need to set rendering order, so might as well 
    // store it?
    
    private SpriteRenderer _renderer;
    public TextMeshPro _costDisplay;
    public TextMeshPro _nameDisplay;
    public TextMeshPro _textDisplay;

    private HandManager _handManager;
    private TargetManager _targetManager;
    private CardPlayManager _cardPlayManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _handManager = FindObjectOfType<HandManager>();
        _targetManager = FindObjectOfType<TargetManager>();
        _cardPlayManager = FindObjectOfType<CardPlayManager>();
        _targetPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = Time.deltaTime * MovementSpeed;
            

        if ((transform.position - _targetPosition).magnitude <= distanceToMove)
        {
            transform.position = _targetPosition;
        }
        else
        {
            transform.position += distanceToMove * (_targetPosition - transform.position);
        }
        
        //float currentAngle = transform.eulerAngles.z;
        //if (currentAngle > 45) currentAngle -= 90;
        //float angleToRotate = Time.deltaTime * RotationSpeed * (_targetAngle > 0f ? 1f : -1f);
        float newAngle = 0f;
        //if (Math.Abs(currentAngle - _targetAngle) < Math.Abs(angleToRotate))
        //{
        //    newAngle = _targetAngle;
        //}
        //else
        //{
        //   newAngle = currentAngle + angleToRotate * (_targetAngle - currentAngle);
        //}
        
        newAngle = _targetAngle;
        transform.eulerAngles = new Vector3();
        transform.Rotate(0,0,newAngle);
    }
    
    
    public void SetPositionInfo(float x, float y, float angle, int index, bool isSelected)
    {
        _targetPosition = new Vector3(x,y,0);
        _targetAngle = angle;
        _index = index;

        if (isSelected)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            _renderer.sortingOrder = 1000;
            _costDisplay.sortingOrder = 1001;
            _nameDisplay.sortingOrder = 1001;
            _textDisplay.sortingOrder = 1001;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            _renderer.sortingOrder = index * 10;
            _costDisplay.sortingOrder = index * 10 + 1;
            _nameDisplay.sortingOrder = index * 10 + 1;
            _textDisplay.sortingOrder = index * 10 + 1;
        }
    }
    
    private void OnMouseEnter()
    {
        if (_targetManager.TargetingModeActive == false)
        {
            _handManager.SetSelected(_index);
        }
    }

    private void OnMouseExit()
    {
        if (_targetManager.TargetingModeActive == false)
        {
            _handManager.ClearSelected();
        }
    }

    private void OnMouseDrag()
    {
        _targetManager.ActivateTargetingMode();
    }

    private void OnMouseUp()
    {
        // if this ia playable and target is valid, play the card
        _cardPlayManager.PlayCardIfValid();    
        
        // reset for next card
        _targetManager.DeactivateTargetingMode();
        _handManager.ClearSelected();
    }
}
