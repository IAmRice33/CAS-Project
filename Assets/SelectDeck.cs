using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectDeck : MonoBehaviour
{
    Button selectButton;
    Deck deck;

    public void DeckSelected(Deck deck)
    {
        this.deck = deck;
    }

    public void Selected()
    {
        GameManager.Instance.playerDeck.AddRange(deck.cards);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
