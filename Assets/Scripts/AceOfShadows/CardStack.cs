using System.Collections.Generic;
using UnityEngine;

namespace AceOfShadows
{
    public class CardStack : MonoBehaviour
    {
        
        List<Card> cards = new List<Card>();

        public void AddCard(Card card)
        {
            cards.Add(card);
            card.transform.position = gameObject.transform.position;
        }
    }
}
