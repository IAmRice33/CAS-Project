using UnityEngine;

public class AI_Brain : MonoBehaviour
{

    public HealthBarUI player;

    public HealthBarUI self;

    public DOT_Logic dot;
    
    public Crit_Logic crit;
    public Card dieCard;
    public Card takeAimCard;
    public Card incinerateCard;
    public void AITurn()
    {
        float roll = UnityEngine.Random.value;
        if (roll <= 1f / 3f)
        {
            dieCard.AIPlay(player, self, crit, dot);

        }
        else if (roll <= 2f / 3f)
        {
            takeAimCard.AIPlay(player, self, crit, dot);
        }
        else
        {
            incinerateCard.AIPlay(player, self, crit, dot);
        }
        crit.ai_focus_count -= 1;
        dot.EnemyStatusTick();

    }

}
