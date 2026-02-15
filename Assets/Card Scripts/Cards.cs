using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]
public abstract class Card : ScriptableObject
{
    public string cardName;
    public Sprite artwork;

    public virtual int energycost => 0;

    public virtual string color => null;

    public abstract void Play(CardDisplay cardDisplay, HealthBarUI target, HealthBarUI self, Crit_Logic crit, TurnManager turnManager, HandManager handManager, DOT_Logic dot, EnergyLogic energy);
    public abstract void AIPlay(HealthBarUI target, HealthBarUI self, Crit_Logic crit, DOT_Logic dot);
}
