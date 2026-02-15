using UnityEngine;

public class Crit_Logic : MonoBehaviour
{
    public float crit_chance = 0.125f;
    public float crit_damage = 2f;
    public int focus_count = 0;

    public float ai_crit_chance = 0.125f;
    public float ai_crit_damage = 2f;
    public int ai_focus_count = 0;
    void Update()
    {
        if (focus_count > 0)
        {
            crit_chance = 0.5f;
        }
        else
        {
            crit_chance = 0.125f;
        }
        if (ai_focus_count > 0)
        {
            ai_crit_chance = 0.5f;
        }
        else
        {
            crit_chance = 0.125f;
        }
    }

}
