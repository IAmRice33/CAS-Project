using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopRender : MonoBehaviour
{
    public Card card;
    public Image artworkImage;

    public TextMeshProUGUI descriptiontext;
    public Shop shop;

    public void Setup(Card card)
    {
        this.card = card;

        if (artworkImage == null)
            Debug.LogError("artworkImage is NULL!");

        if (card == null)
            Debug.LogError("card is NULL!");

        if (card != null && card.artwork == null)
            Debug.LogError("card.artwork is NULL!");

        artworkImage.sprite = card.artwork;
        descriptiontext.text = card.description;
    }

    public void Selected()
    {
        if (shop == null)
        {
            Debug.LogError("Shop reference is null!");
            return;
        }
        shop.CardSelected(card);
        Destroy(gameObject);
    }
}
