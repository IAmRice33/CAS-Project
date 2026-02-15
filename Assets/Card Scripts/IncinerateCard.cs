using UnityEngine;

[CreateAssetMenu(fileName = "IncinerateCard", menuName = "Cards/Incinerate Card")]

public class IncinerateCard : Card
{
    public float damage = 30f;
    public override int energycost => 1;

    public override string color => "red";


    public override void Play(CardDisplay cardDisplay, HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        if (turnManager.playerTurn)
        {
            Debug.Log("Used Incinerate: Burn Applied");
            // Set burn duration — you probably store this in DOT_Logic
            dot.burn_duration = 3;

            if (Random.value <= crit.crit_chance)
            {
                targetHealthBar.TakeDamage(damage * crit.crit_damage / Mathf.Pow(2, dot.ai_sh_stack));
                Debug.Log("It's a critical hit!");
            }
            else
            {
                targetHealthBar.TakeDamage(damage / Mathf.Pow(2, dot.ai_sh_stack));
            }
            energy.energycount -= energycost;
            // turnManager.EndPlayerTurn();
        }
    }

    public override void AIPlay(HealthBarUI targetHealthBar, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy Used Incinerate!");
        dot.ai_burn_duration = 3;

        if (Random.value <= crit.ai_crit_chance)
        {
            targetHealthBar.TakeDamage(damage * crit.ai_crit_damage / Mathf.Pow(2, dot.sh_stack));
            Debug.Log("It's a critical hit!");
        }
        else
        {
            targetHealthBar.TakeDamage(damage / Mathf.Pow(2, dot.sh_stack));
        }
    }
}