using UnityEngine;

namespace Inspire
{
    public class PotentialTarget : MonoBehaviour
    {
        private TargetManager _targetManager;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _targetManager = FindObjectOfType<TargetManager>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseEnter()
        {
            if (_targetManager.TargetingModeActive)
            {
                _targetManager.CheckTarget(this);
            }
        }
        
        private void OnMouseExit()
        {
            _targetManager.ClearTarget();
            _renderer.color = Color.white;
        }
    }
}