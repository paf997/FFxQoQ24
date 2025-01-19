using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerCard", menuName = "Game/PlayerCard", order = 1)]
public class PlayerCardSO : ScriptableObject
{

    public Sprite cardBackgroundImg;
    public Sprite cardActionIcon;
    public Sprite cardCostIcon;

    [Header("Card Properties")]
    public string Name;
    public int cost; 

    public int colorCosts;
    public int duration;   
    public int mAttAdjustment;
    public int defAdjustment;
    int deckIndex;        
    [TextArea]
    public string description;  
}