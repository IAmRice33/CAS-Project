using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public TurnManager turnManager;
    public HealthBarUI enemyHealthBar;
    public Crit_Logic crit;
    public DOT_Logic dotLogic;

    public List<Card> deck = new List<Card>();
    public List<Card> drawPile;
    public List<Card> discardPile = new List<Card>();

    public List<GameObject> hand = new List<GameObject>();

    public List<Card> allCards = new List<Card>();  // Drag all your DieCard, TakeAimCard, IncinerateCard assets here
    public GameObject cardDisplayPrefab; // The UI prefab
    public Transform handArea;           // Parent to spawn the card UI under

    
    public void Draw(int numberOfCards)
    {
        // Clear any leftover cards from previous hand

        for (int i = 0; i < numberOfCards; i++)
        {
            // int index = Random.Range(0, allCards.Count);
            // Card drawnCard = allCards[index];

            if (drawPile.Count == 0)
            {
                if (discardPile.Count == 0)
                {
                    Debug.Log("No cards left to draw.");
                    return;
                }

                // Refill draw pile
                drawPile.AddRange(discardPile);
                discardPile.Clear();
                Debug.Log("Draw Pile Refilled");
                ShufflePile(drawPile);
            }

            Card drawnCard = drawPile[0];
            drawPile.RemoveAt(0);

            GameObject cardGO = Instantiate(cardDisplayPrefab, handArea);
            hand.Add(cardGO);
            cardGO.SetActive(true); // Ensure the instantiated card is active
            CardDisplay display = cardGO.GetComponent<CardDisplay>();

            display.Setup(drawnCard);
        }
    }
    public void DiscardRandomCards(int amount)
    {
        int cardsToDiscard = Mathf.Min(amount, hand.Count);

        for (int i = 0; i < cardsToDiscard; i++)
        {
            int randomIndex = Random.Range(0, hand.Count);
            GameObject cardGO = hand[randomIndex];

            Card card = cardGO.GetComponent<CardDisplay>().card;
            discardPile.Add(card);

            hand.RemoveAt(randomIndex);
            Destroy(cardGO);
        }
    }
    public void DiscardCard(GameObject cardGO)
    {
    Card card = cardGO.GetComponent<CardDisplay>().card;
    discardPile.Add(card);

    hand.Remove(cardGO);
    Destroy(cardGO);
    }

    public void ShufflePile(List<Card> pile)
    {
        for (int i = 0; i < pile.Count; i++)
        {
            Card temp = pile[i];
            int randomIndex = Random.Range(i, pile.Count);
            pile[i] = pile[randomIndex];
            pile[randomIndex] = temp;
        }
    }
    void Start()
    {
        drawPile = new List<Card>(deck);
        ShufflePile(drawPile);
        Draw(3);
    }
}