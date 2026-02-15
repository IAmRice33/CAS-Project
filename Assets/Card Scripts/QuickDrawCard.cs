using Unity.Mathematics.Geometry;
using UnityEngine;

[CreateAssetMenu(fileName = "QuickDrawCard", menuName = "Cards/Quick Draw Card")]

public class QuickDrawCard : Card
{

    public int num = 3;

    public override int energycost => 2;

    public override string color => "yellow";

    public override void Play(CardDisplay cardDisplay, HealthBarUI target, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        if (turnManager.playerTurn)
        {
            Debug.Log("Quick Draw drew 3 cards!");
            handManager.Draw(num);
            energy.energycount -= energycost;

        }
    }

    public override void AIPlay(HealthBarUI target, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy Used Quick Draw!");
    }
}
