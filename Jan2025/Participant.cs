using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UI;

public enum Target { player, enemy, self }
public enum Row{ front, back }

public class Participant : MonoBehaviour
{
    public int hp;
    public int maxHP;
    [SerializeField] int def;
    [SerializeField] int poisonDmg;
    [SerializeField] int att;
    [SerializeField] int baseAtt;
    [SerializeField] bool isDoneTurn;
    public int initiative;
    private BattleAbility currentAbility;
    [SerializeField] List<BattleAbility> conditions = new List<BattleAbility>() { };
    [SerializeField] List<StatTypes> typeList = new List<StatTypes>() { };
    [SerializeField] Target targetName;
    [SerializeField] Button initiativeIconBtn;
    [SerializeField] Dictionary <string, int> stats = new Dictionary<string, int>();

    //[SerializeField] Participant participant;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AdjustStats(string type, int value)
    {
        int baseValue = stats[type];
        //baseValue +- modifiers
        //calculate change
    }

    public int GetInitiative()
    {
        return initiative;
    }

    public Button GetInitiativeIcon()
    {
        return initiativeIconBtn;
    }

    public void AddCondition(BattleAbility data)
    {
        conditions.Add(data);
    }

    // Update is called once per frame
    public void SetTurnInitiative(int init)
    {
        initiative = init;
    }

    public Target GetTarget()
    {
        return targetName;
    }

    public int GetDef()
    {
        return def;
    }

    public int GetHP()
    {
        return hp;
    }

    public void AdjustHP(int amount)
    {
        hp = (hp - amount);
        IsDead();
    }

    public int IsHealthFull(int currentHealth)
    {
        if (currentHealth < maxHP)
        {
            return maxHP;
        }
        else
        {
            return currentHealth;
        }
    }

    public bool IsDead()
    {
        return (hp < 1);
    }

    public int AdjustAtt(int amount)
    {
        return (att += amount) > 1 ? (att += amount) : 1;
    }

    /*public void checkCurrentConditons(){

        for(int i = 0; i < conditions.Count; i++) {
            BattleAbility condition = conditions[i];
            int adj = condition.adjustment[i];
            if(condition.duration > 0){
                att = (baseAtt - adj);
                condition.duration --;
            }else{
                conditions.RemoveAt(i);
            }
        }
    }*/

    public void IsPoisoned()
    {
        if (poisonDmg > 0)
        {
            att = baseAtt - 1;
            poisonDmg--;
        }
    }

    public void AdjustDef(int type, int adjustment)
    {
        if (type == 0)
        {
            def = def + adjustment;
        }
        int[] tempStats = new int[3] { def, 0, 0 };
        //updateStatUI(tempStats);
    }

    public BattleAbility GetCurrentAction()
    {
        return currentAbility;
    }

    public Participant GetParticipantScript()
    {
        return this;
    }
}
