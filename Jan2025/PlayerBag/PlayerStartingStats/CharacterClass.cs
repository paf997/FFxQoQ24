using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterClass", menuName = "Game/CharacterClass", order = 1)]
public class CharacterClass : ScriptableObject
{
    public enum CharacterClassType { Warrior, Rogue, WhiteMage, BlackMage, RedMage }
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField] int maxHP;
    [SerializeField] int luck;
    [SerializeField] int speed;
    [SerializeField] CharacterClassType characterClass;
    [SerializeField] List<Token> startingTokens;
    [SerializeField] List<GameObject> startingEquipment = new List<GameObject>();

    public int GetMaxHP()
    {
        return maxHP;
    }

    public int GetSpeed()
    {
        return 0;
    }

    public int GetLuck()
    {
        return 0;
    }

    public List<Token> GetStartingTokens()
    {
        return startingTokens;
    }

    public  List <GameObject> GetStartingGear()
    {
        return startingEquipment;
    }
}
