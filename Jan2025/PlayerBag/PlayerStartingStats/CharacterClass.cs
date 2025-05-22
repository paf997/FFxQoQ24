using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "CharacterClass", menuName = "Game/CharacterClass", order = 1)]
public class CharacterClass : ScriptableObject
{
    public enum CharacterClassType  { Warrior, Rogue, WhiteMage, BlackMage, RedMage }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] int maxHP;
    [SerializeField] CharacterClassType characterClass;
    [SerializeField] List <Token> startingTokens;

    public int GetMaxHP(){
        return maxHP;
    }

    public List<Token> GetStartingTokens(){
        return startingTokens;
    }
}
