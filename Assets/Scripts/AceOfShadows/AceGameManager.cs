using System.Collections.Generic;
using UnityEngine;

namespace AceOfShadows
{
    public class AceGameManager : MonoBehaviour
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private List<CardStack> cardStacks = new List<CardStack>();
        [SerializeField] private int numberOfCards = 144;

        private static AceGameManager instance; // singleton



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

        private void SetupGame()
        {
            // Spawn the cards into the first stack
            for (int i = 0; i < numberOfCards; i++)
            {
                Card card = Instantiate(cardPrefab);
                cardStacks[0].AddCard(card);
            }
        }
    }
}
