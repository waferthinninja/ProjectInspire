using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class CardPlayManager : MonoBehaviour
{
    private HandManager _handManager;
    private TargetManager _targetManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        _handManager = FindObjectOfType<HandManager>();
        _targetManager = FindObjectOfType<TargetManager>();
    }
    
    public void PlayCardIfValid()
    {
        Card card = _handManager.GetSelectedCard();

        if (card != null)
        {
            PotentialTarget target = _targetManager.GetTarget();

            if (card.GetTargetType() == TargetType.Enemy)
            {
                card.Play();
                Destroy(card.gameObject);
            }
        }
    }
}
