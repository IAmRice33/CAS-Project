using System.Collections.Generic;
using UnityEngine;
public class DeckDisplay : MonoBehaviour
{
    public GameObject deckDisplayPrefab;
    public Transform deckArea;

    public List<Deck> decks;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Deck deck in decks)
        {
            GameObject deckdisplay = Instantiate(deckDisplayPrefab, deckArea);
            deckdisplay.SetActive(true);
            DeckRender deckrender = deckdisplay.GetComponent<DeckRender>();
            deckrender.Setup(deck);
        }
    }

}
