// using System.Collections.Generic;
// using UnityEngine;

// public class Deck : MonoBehaviour
// {
//     public List<Card> cards; // Fill this in Inspector with your cards
//     public Transform handArea; // UI parent for spawned cards
//     public GameObject cardPrefab; // A UI prefab to display a card

//     public void DrawCard()
//     {
//         if (cards.Count == 0) return;

//         // Pick a random card or top card
//         int index = Random.Range(0, cards.Count);
//         Card drawnCard = cards[index];
//         cards.RemoveAt(index);

//         // Create its visual representation
//         GameObject cardGO = Instantiate(cardPrefab, handArea);
//         cardGO.GetComponent<CardDisplay>().Setup(drawnCard);
//     }
// }