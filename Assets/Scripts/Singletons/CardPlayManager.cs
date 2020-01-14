using System.Collections;
using System.Collections.Generic;
using Inspire;
using UnityEngine;

public class CardPlayManager : MonoBehaviour
{
    private HandManager _handManager;
    private TargetManager _targetManager;
    private EnergyManager _energyManager;
    private DiscardManager _discardManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        _handManager = FindObjectOfType<HandManager>();
        _targetManager = FindObjectOfType<TargetManager>();
        _energyManager = FindObjectOfType<EnergyManager>();
        _discardManager = FindObjectOfType<DiscardManager>();
    }
    
    public void PlayCardIfValid()
    {
        Card card = _handManager.GetSelectedCard();

        if (card != null)
        {
            PotentialTarget target = _targetManager.GetTarget();

            if 
            (
                 (card.GetTargetType() == TargetType.None)
              || (card.GetTargetType() == TargetType.Enemy && target != null && target.GetComponentInParent(typeof(Enemy)) != null )
              || (card.GetTargetType() == TargetType.Friendly && target != null && (target.GetComponentInParent(typeof(Carrier)) != null || target.GetComponentInParent(typeof(Fighter)) != null) )
            )
            {
                PlayCard(card);
            }
        }
    }

    public void PlayCard(Card card)
    {
        card.Play();
        _energyManager.ChangeEnergy(-card.GetCost());
        DiscardCard(card);
    }

    public void DiscardCard(Card card)
    {
        card.transform.SetParent(_discardManager.transform);
        card.GetComponent<VisibilityManager>().Hide();

    }
}
