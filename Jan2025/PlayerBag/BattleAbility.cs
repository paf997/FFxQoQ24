using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StatTypes  { att, attRange, attMagic, def, poison, magic, bust}

[CreateAssetMenu(fileName = "BattleAbility", menuName = "Game/BattleAbility", order = 1)]
public class BattleAbility : ScriptableObject {
    [Header("Name")]

    public string name;
    public List <StatTypes> type = new List<StatTypes>(){};

    //public List <string> type = new List<string>(){};
    public List <int> adjustment = new List<int>(){};
    public int initiative;
    public int probability;
    public int nTimePlayed;
    public int maxPlayed;
    public int duration;
    public Target target;
}


