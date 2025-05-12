using System.Collections.Generic;
using UnityEngine;

namespace AceOfShadows
{
    public class CardStack : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = new Vector3(5, 5, 1);
        List<Card> cards = new List<Card>();

        public void AddCard(Card card)
        {
            card.transform.position = GetCardPositionAtIndex(cards.Count);
            card.SetLayer(cards.Count);
            cards.Add(card);
        }

        public int GetCardCount()
        {
            return cards.Count;
        }

        public void MoveTopCardToStack(CardStack stack)
        {
            if (cards.Count == 0) return;
            if (stack == null || stack == this) return;

            Card topCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);

            stack.AddCard(topCard);

            
        }

        private Vector3 GetCardPositionAtIndex(int index)
        {
            return gameObject.transform.position + (offset * index);
        }
    }
}
