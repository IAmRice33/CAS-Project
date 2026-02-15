using UnityEngine;

[CreateAssetMenu(fileName = "TakeAimCard", menuName = "Cards/Take Aim Card")]

public class TakeAimCard : Card
{
    public override int energycost => 2;

    public override string color => "yellow";

    public override void Play(CardDisplay cardDisplay, HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        if (turnManager.playerTurn)
        {
            Debug.Log("Used Take Aim: Focus buffed");
            crit.focus_count = 3;
            energy.energycount -= energycost;
            // turnManager.EndPlayerTurn();

        }
    }

    public override void AIPlay(HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy used Take Aim!");
        crit.ai_focus_count = 3;
    }
}
