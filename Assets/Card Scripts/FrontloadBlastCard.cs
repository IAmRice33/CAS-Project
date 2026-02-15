using Unity.Mathematics.Geometry;
using UnityEngine;

[CreateAssetMenu(fileName = "FrontloadBlastCard", menuName = "Cards/Frontload Blast Card")]

public class FrontloadBlastCard : Card
{

    public float damage = 250f;

    public float recoil = 50f;

    public override int energycost => 2;
    public override string color => "red";


    public override void Play(CardDisplay cardDisplay, HealthBarUI target, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy)
    {
        if (turnManager.playerTurn)
        {
            Debug.Log("Used Frontload Blast!");
            if (Random.value <= crit.crit_chance)
            {
                target.TakeDamage(damage * crit.crit_damage / Mathf.Pow(2, dot.ai_sh_stack));
                Debug.Log("It's a critical hit!");
            }
            else
            {
                target.TakeDamage(damage / Mathf.Pow(2, dot.ai_sh_stack));
            }
            if (Random.value <= crit.crit_chance)
            {
                self.TakeDamage(recoil * crit.crit_damage / Mathf.Pow(2, dot.sh_stack));
                Debug.Log("It's a critical hit!");
            }
            else
            {
                self.TakeDamage(recoil / Mathf.Pow(2, dot.sh_stack));
            }
            energy.energycount -= energycost;
            // turnManager.EndPlayerTurn();
        }
    }

    public override void AIPlay(HealthBarUI target, HealthBarUI self, Crit_Logic crit, DOT_Logic dot)
    {
        Debug.Log("Enemy Used Frontload Blast!");

        if (Random.value <= crit.ai_crit_chance)
        {
            target.TakeDamage(damage * crit.ai_crit_damage / Mathf.Pow(2, dot.sh_stack));
            Debug.Log("It's a critical hit!");
        }
        else
        {
            target.TakeDamage(damage / Mathf.Pow(2, dot.sh_stack));
        }
        if (Random.value <= crit.crit_chance)
            {
                target.TakeDamage(recoil * crit.crit_damage / Mathf.Pow(2, dot.ai_sh_stack));
                Debug.Log("It's a critical hit!");
            }
        else
        {
            target.TakeDamage(recoil / Mathf.Pow(2, dot.ai_sh_stack));
        }
    }
}