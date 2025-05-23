using System.Collections.Generic;
using UnityEngine;

namespace AceOfShadows
{
    public class AceGameManager : MonoBehaviour
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private List<CardStack> cardStacks = new List<CardStack>();
        [SerializeField] private int numberOfCards = 144;
        [SerializeField] private float cardDealTime = 1;
        [SerializeField] private float cardMoveSpeed = 1;

        private static AceGameManager instance; // singleton

        private float dealTimer = 0;

        private void Awake()
        {
            instance = this;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Start()
        {
            SetupGame();
        }

        private void Update()
        {
            if (cardStacks[0].GetCardCount() == 0)
            {
                // game finished
                AceGameUI.ShowGameFinishedUI();
                return;
            }

            dealTimer += Time.deltaTime;
            if (dealTimer >= cardDealTime)
            {
                dealTimer = 0;
                DealCard();
            }
        }

        private void SetupGame()
        {
            // Spawn the cards into the first stack
            for (int i = 0; i < numberOfCards; i++)
            {
                Card card = Instantiate(cardPrefab);
                cardStacks[0].AddCard(card);
            }
        }

        private void DealCard()
        {
            int targetStackIndex = Random.Range(1, cardStacks.Count);
            cardStacks[0].MoveTopCardToStack(cardStacks[targetStackIndex]);
        }

        // Static interface
        public static float GetCardMoveSpeed()
        {
            if (instance == null) return 1;
            return instance.cardMoveSpeed;
        }
    }
}
