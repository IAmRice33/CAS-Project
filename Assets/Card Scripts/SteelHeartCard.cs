using UnityEngine;

[CreateAssetMenu(fileName = "SteelHeartCard", menuName = "Cards/Steel Heart Card")]

public class SteelHeartCard : Card
{
    public override int energycost => 2;

    public override string color => "blue";


    public override void Play(CardDisplay cardDisplay, HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        if (turnManager.playerTurn)
        {
            Debug.Log("The Steel Heart strengthened your defense");
            // Set Steel Heart Duration
            dot.steel_heart_duration = 3;
            dot.sh_stack++;
            energy.energycount -= energycost;
            // turnManager.EndPlayerTurn();
        }
    }

    public override void AIPlay(HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy used Steel Heart!");
        dot.steel_heart_duration = 2;   
        dot.ai_sh_stack++;
    }
}