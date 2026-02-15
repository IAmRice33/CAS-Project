using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool playerTurn = true;

    public AI_Brain aiBrain;
    public HandManager handManager; // Optional: draws cards
    public Crit_Logic crit;
    public DOT_Logic dotLogic; // Optional: run DoT at start of AI turn

    public EnergyLogic energy;

    public void EndPlayerTurn()
    {
        playerTurn = false;
        energy.energycount = 5;
        crit.focus_count -= 1;


        // Run DOT, AI turn, etc.
        dotLogic.PlayerStatusTick();   // Only if you have DOT
        aiBrain.AITurn();

        crit.ai_focus_count -= 1;


        playerTurn = true;

        // Draw new hand
        handManager.Draw(2);
    }
}