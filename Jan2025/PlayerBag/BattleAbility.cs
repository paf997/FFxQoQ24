using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "BattleAbility", menuName = "Game/BattleAbility", order = 1)]
public class BattleAbility : ScriptableObject {
    [Header("Name")]

    public string name;
    public enum StatTypes  {att, attRange, attMAgic}
    public List <StatTypes> type = new List<StatTypes>(){};

    //public List <string> type = new List<string>(){};
    public List <int> adjustment = new List<int>(){};
    public int initiative;
    public int probability;
    public int nTimePlayed;
    public int maxPlayed;
}


