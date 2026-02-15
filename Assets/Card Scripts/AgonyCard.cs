using Unity.Mathematics.Geometry;
using UnityEngine;

[CreateAssetMenu(fileName = "AgonyCard", menuName = "Cards/Agony Card")]

public class AgonyCard : Card
{

    public float flatdamage = 100f;
    public float scalingdamage = 250f;

    public override int energycost => 2;

    public override string color => "red";

    public override void Play(CardDisplay cardDisplay, HealthBarUI target, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        Debug.Log("Used Agony");
        if (turnManager.playerTurn)
        {

            if (Random.value <= crit.crit_chance)
            {
                target.TakeDamage((flatdamage + Mathf.Pow((1-(self.currentHP/self.maxHP)), 2)*scalingdamage) * crit.crit_damage / Mathf.Pow(2, dot.ai_sh_stack));
                Debug.Log("It's a critical hit!");
            }
            else
            {
                target.TakeDamage((flatdamage + Mathf.Pow((1-(self.currentHP/self.maxHP)), 2)*scalingdamage) / Mathf.Pow(2, dot.ai_sh_stack));
            }
            energy.energycount -= energycost;
            // turnManager.EndPlayerTurn();
        }
    }

    public override void AIPlay(HealthBarUI target, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy used Basic Attack!");
        if (Random.value <= crit.ai_crit_chance)
        {
            target.TakeDamage(flatdamage * crit.ai_crit_damage / Mathf.Pow(2, dot.sh_stack));
            Debug.Log("It's a critical hit!");
        }
        else
        {
            target.TakeDamage(flatdamage / Mathf.Pow(2, dot.sh_stack));
        }
    }
}