using UnityEngine;
using UnityEngine.UI;

public class DeckRender : MonoBehaviour
{
    public Deck deck;
    public Image artworkImage;

    public void Setup(Deck deck)
    {
        this.deck = deck;

        artworkImage.sprite = deck.artwork;
    }
}
