using UnityEngine;

public enum TokenColor  {white, red, blue, yellow, green, orange, purple, wild}

[CreateAssetMenu(fileName = "NewToken", menuName = "Game/Token", order = 1)]
public class Token : ScriptableObject
{
    [Header("Token Properties")]
    public string name;
    public int value;            // Numeric value of the token
    public string color2;         // Token color
    public StatTypes type;    
    public StatTypes subType;       // Type/category of the token
    public TokenColor color;
    public Sprite Sprite;
  

    [TextArea]
    public string description;   // Optional description of the token
}

