using Unity.Mathematics.Geometry;
using UnityEngine;

[CreateAssetMenu(fileName = "RefundCard", menuName = "Cards/Refund Card")]

public class RefundCard : Card
{

    public int num = 5;

    public override int energycost => 1;

    public override string color => "yellow";

    public override void Play(CardDisplay cardDisplay, HealthBarUI target, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        if (turnManager.playerTurn)
        {
            for (int i = handManager.hand.Count - 1; i >= 0; i--)
            {
                if (handManager.hand[i] != cardDisplay.gameObject)
                {
                    handManager.DiscardCard(handManager.hand[i]);
                }
            }
            Debug.Log("Refunded hand for 5 cards!");
            handManager.Draw(num);
            energy.energycount -= energycost;

        }
    }

    public override void AIPlay(HealthBarUI target, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy Used Quick Draw!");
    }
}
