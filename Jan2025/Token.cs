using UnityEngine;

[CreateAssetMenu(fileName = "NewToken", menuName = "Game/Token", order = 1)]
public class Token : ScriptableObject
{
    [Header("Token Properties")]
    public string Name;
    public int value;            // Numeric value of the token
    public string color;         // Token color
    public string type;          // Type/category of the token

    [TextArea]
    public string description;   // Optional description of the token
}

