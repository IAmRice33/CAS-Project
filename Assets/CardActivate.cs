using UnityEngine;
using UnityEngine.UI;

public class CardActivate : MonoBehaviour
{
    public Image artworkImage;
    public Text nameText;
    public Button playButton;

    public Card cardData; // can be any Card: DieCard, TakeAimCard, etc.
    public HealthBarUI target;

    public HealthBarUI player;
    public Crit_Logic crit;
    public DOT_Logic dot;

    public EnergyLogic energy;

    public TurnManager turnManager;

    public HandManager hand;
    void OnMouseDown()
    {
        // cardData.Play(, target, player, crit, turnManager, hand, dot , energy);
        // Debug.Log("Used Die");
    }
}