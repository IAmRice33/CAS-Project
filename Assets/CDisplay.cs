using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CDisplay : MonoBehaviour
{
    public GameObject cardDisplayPrefab;
    public Transform cardArea;
    public Deck deck;
    public Shop shop;
    Card[] inShop = new Card[5];
    int index;
    int count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (shop == null)
        {
            Debug.LogError("CDisplay shop reference is NULL!");
        }
        else
        {
            Debug.Log("CDisplay shop reference assigned correctly.");
        }
        for (int i = 0; i < 5; i++)
        {
            index = Random.Range(0, deck.Length());
            inShop[i] = deck.cards[index];
        }

        foreach(Card card in inShop)
        {
            GameObject carddisplay = Instantiate(cardDisplayPrefab, cardArea);
            carddisplay.SetActive(true);
            ShopRender shoprender = carddisplay.GetComponent<ShopRender>();
            shoprender.shop = shop;
            shoprender.Setup(card);
        }
    }
}
