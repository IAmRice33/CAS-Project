using UnityEngine;

public class DOT_Logic : MonoBehaviour
{
    public int burn_duration = 0;

    public float burn_damage = 30f;

    public int ai_burn_duration = 0;

    public float ai_burn_damage = 30f;

    public int steel_heart_duration = 0;

    public int sh_stack = 0;

    public int ai_steel_heart_duration = 0;

    public int ai_sh_stack = 0;

    public HealthBarUI playerhealthBar;

    public HealthBarUI enemyhealthBar;


    public void PlayerStatusTick()
    {
        if (burn_duration > 0)
        {
            burn_duration -= 1;
            enemyhealthBar.TakeDamage(burn_damage);
            Debug.Log("Burn damage dealt");
        }
        if (steel_heart_duration > 0)
        {
            steel_heart_duration -= 1;
        }
        if (steel_heart_duration == 0)
        {
            sh_stack = 0;
        }
    }

    public void EnemyStatusTick()
    {
        if (ai_burn_duration > 0)
        {
            ai_burn_duration -= 1;
            playerhealthBar.TakeDamage(ai_burn_damage);
            Debug.Log("Burn damage taken");
        }
        if (ai_steel_heart_duration > 0)
        {
            ai_steel_heart_duration -= 1;
        }
        if (ai_steel_heart_duration == 0)
        {
            ai_sh_stack = 0;
        }
    }
}
