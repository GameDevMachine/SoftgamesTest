using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AceOfShadows
{
    public class CardStack : MonoBehaviour
    {
        [SerializeField] private TMP_Text cardCountText;
        [SerializeField] private Vector3 offset = new Vector3(5, 5, 1);
        List<Card> cards = new List<Card>();

        // instantly adds a card to this stack
        public void AddCard(Card card)
        {
            card.transform.position = GetCardPositionAtIndex(cards.Count);
            card.SetLayer(cards.Count);
            cards.Add(card);
            UpdateCardStackUI();
        }

        // moves a card to the top of this stack smoothly
        public void MoveCard(Card card)
        {
            cards.Add(card);
            card.MoveToPositionAndLayer(GetCardPositionAtIndex(cards.Count), cards.Count);
            UpdateCardStackUI();
        }

        public int GetCardCount()
        {
            return cards.Count;
        }

        public void MoveTopCardToStack(CardStack targetStack)
        {
            if (cards.Count == 0) return;
            if (targetStack == null || targetStack == this) return;

            // remove top card from this stack
            Card topCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            UpdateCardStackUI();

            // move card to target stack
            targetStack.MoveCard(topCard);
        }

        private Vector3 GetCardPositionAtIndex(int index)
        {
            return gameObject.transform.position + (offset * index);
        }

        private void UpdateCardStackUI()
        {
            cardCountText.text = cards.Count.ToString();
        }
    }
}
