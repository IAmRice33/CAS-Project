using UnityEngine;
using UnityEngine.UI;

public class DeckRender : MonoBehaviour
{
    public Deck deck;
    public GameObject carddeckDisplayPrefab;

    public Transform carddeckArea;
    public Image artworkImage;

    public GameObject deckcardsdisplay;

    public SelectDeck selectDeck;

    public void Setup(Deck deck)
    {
        this.deck = deck;

        artworkImage.sprite = deck.artwork;
    }
    public void OpenDeck()
    {
        Debug.Log("Opening Deck...");

        deckcardsdisplay.SetActive(false);

        for (int i = carddeckArea.childCount - 1; i >= 1; i--)
        {
            Destroy(carddeckArea.GetChild(i).gameObject);
        }

        deckcardsdisplay.SetActive(true);

        Debug.Log("Deck count: " + deck.cards.Count);

        foreach(Card card in deck.cards)
        {
            Debug.Log("Spawning card: " + card.name);
            GameObject cardGO = Instantiate(carddeckDisplayPrefab, carddeckArea);
            cardGO.SetActive(true); // Ensure the instantiated card is active
            CardDisplay display = cardGO.GetComponent<CardDisplay>();
            display.Setup(card);
        }

        selectDeck.DeckSelected(deck);
    }
    public void CloseDeck()
    {
        Debug.Log("Closing Deck...");
        deckcardsdisplay.SetActive(false);
    }
}
