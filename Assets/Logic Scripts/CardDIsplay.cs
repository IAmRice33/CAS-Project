using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Image artworkImage;

    public Card card;
    public TurnManager turnManager;
    public HealthBarUI enemyHealthBar;

    public HealthBarUI playerHealthBar;
    public Crit_Logic crit;
    public DOT_Logic dotLogic;

    public HandManager hand;
    public EnergyLogic energy;

    // Setup the card’s data & context
    public void Setup(Card card)
    {
        this.card = card;

        artworkImage.sprite = card.artwork;
    }

    // Hook this up to a Button’s OnClick event
    public void PlayCard()
    {
        if (turnManager.playerTurn && energy.energycount >= card.energycost)
        {
            Debug.Log("Playing Card...");
            card.Play(this, enemyHealthBar, playerHealthBar, crit, turnManager, hand, dotLogic, energy);
            hand.DiscardCard(gameObject);
            // Destroy(gameObject); // Remove from UI when played
        }
    }
}