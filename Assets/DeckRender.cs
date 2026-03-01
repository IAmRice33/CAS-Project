using UnityEngine;
using UnityEngine.UI;

public class DeckRender : MonoBehaviour
{
    public Deck deck;
    public GameObject carddeckDisplayPrefab;

    public Transform carddeckArea;
    public Image artworkImage;

    public GameObject deckcardsdisplay;

    public void Setup(Deck deck)
    {
        this.deck = deck;

        artworkImage.sprite = deck.artwork;
    }
    public void OpenDeck()
    {
        Debug.Log("Opening Deck...");
        foreach(Card card in deck.cards)
        {
            deckcardsdisplay.SetActive(true);
            GameObject cardGO = Instantiate(carddeckDisplayPrefab, carddeckArea);
            cardGO.SetActive(true); // Ensure the instantiated card is active
            CardDisplay display = cardGO.GetComponent<CardDisplay>();
            display.Setup(card);
            
        }
        
    }
    public void CloseDeck()
    {
        Debug.Log("Closing Deck...");
        deckcardsdisplay.SetActive(false);
    }
}
