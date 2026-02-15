using UnityEngine;


public class turn_reset : MonoBehaviour
{
    public TurnManager turnManager;
    void OnMouseDown()
    {
        turnManager.EndPlayerTurn();
    }
}
