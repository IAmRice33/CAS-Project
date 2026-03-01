using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]
public abstract class Deck : ScriptableObject
{
    public string deckName;
    public Sprite artwork;

    public List<Card> cards; 

    public abstract void Select();

}

