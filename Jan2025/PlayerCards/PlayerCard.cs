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
    [SerializeField] int abilityIndex;
    [SerializeField] bool ability1HaveToBeActive;
    [SerializeField] bool ability2HaveToBeActive;
    public bool isAvailable;
    public int colorCosts; //new
    public int duration;   
    public int mAttAdjustment;
    public int defAdjustment;//
    public TokenColor tokenColor;
    int deckIndex;        
    [TextArea]
    public string description;  
}