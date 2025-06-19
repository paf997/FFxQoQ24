using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatTypes  { att, attRange, attMagic, def, poison, magic, bust}

[CreateAssetMenu(fileName = "BattleAbility", menuName = "Game/BattleAbility", order = 1)]
public class BattleAbility : ScriptableObject
{
    [Header("Name")]

    public List<StatTypes> type = new List<StatTypes>() { };

    //public List <string> type = new List<string>(){};
    public List<int> adjustment = new List<int>() { };
    [SerializeField] int initiative;
    [SerializeField] string abilityToText;
    public int probability;
    public int nOfTotalInDeck;
    public int totalInDeck;
    public Target target;

    public int GetInitiative()
    {
        return initiative;
    }

    public string GetAbilityToText()
    {
        if (abilityToText != null) return  $"{abilityToText} init {initiative}";
        return "empty";
    }
}


