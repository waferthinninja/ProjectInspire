using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime.DynamicDispatching;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Inspire
{
    public class Card : MonoBehaviour
    {
        
        private string Name;
        private CardType Type;
        private List<CardEffect> Effects;
        private int BaseCost;

        // position handling - could move to another class
        private Vector3 _targetPosition;
        private float _targetAngle;
        public float MovementSpeed = 5f;
        public float RotationSpeed = 1f;

        private int _index; // not sure if this is a good way, store position in hand
                            // but need to set rendering order, so might as well 
                            // store it?
        private SpriteRenderer _renderer;
        private TextMeshPro _costDisplay;
        
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _costDisplay = GetComponentInChildren<TextMeshPro>();
            
            // for now, assign a random cost between 0 and 4
            BaseCost = Random.Range(0, 5);

            _targetPosition = transform.position;
        }

        private void Update()
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

        public void SetPositionInfo(float x, float y, float angle, int index)
        {
            _targetPosition = new Vector3(x,y,0);
            _targetAngle = angle;
            _index = index;
            _renderer.sortingOrder = index * 10;
            _costDisplay.sortingOrder = index * 10 + 1;
        }

        public int GetCost()
        {
            return BaseCost;
        }
    }
}