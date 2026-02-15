using UnityEngine;

[CreateAssetMenu(fileName = "RecolourYellowCard", menuName = "Cards/Recolour: Yellow Card")]

public class RecolourYellow : Card
{
    public override int energycost => 0;

    public override string color => "yellow";


    public override void Play(CardDisplay cardDisplay, HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        bool found = false;

        if (turnManager.playerTurn)
        {

            for (int i = 0; i < handManager.drawPile.Count; i++)
            {
                Card temp = handManager.drawPile[i];

                if (temp.color == "yellow")
                {
                    handManager.drawPile.RemoveAt(i);
                    handManager.drawPile.Insert(0, temp);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Debug.Log("No Yellow Cards in Draw Pile!");
            }
            energy.energycount -= energycost;
            // turnManager.EndPlayerTurn();

        }
    }

    public override void AIPlay(HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy used red!");
        crit.ai_focus_count = 3;
    }
}
