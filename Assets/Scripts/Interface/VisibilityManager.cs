using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inspire
{
    public class VisibilityManager : MonoBehaviour
    {
        private List<Renderer> _renderers;


        private void Awake()
        {
            _renderers = GetComponentsInChildren<Renderer>().ToList();
            
        }

        public void Hide()
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = false;
            }
        }

        public void Show()
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = true;
            }
            
        }
    }
}