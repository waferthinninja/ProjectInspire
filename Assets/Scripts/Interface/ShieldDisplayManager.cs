using Inspire.Components;
using TMPro;
using UnityEngine;

namespace Inspire
{
    public class ShieldDisplayManager : MonoBehaviour
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
            if (_target.GetCurrentShield() > 0)
            {
                _text.text = _target.GetCurrentShield().ToString();
            }
            else
            {
                _text.text = "";
            }
        }
    }
}