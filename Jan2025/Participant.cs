using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target{ player1, enemy1, enemy2 }

public class Participant : MonoBehaviour{
    public int health;
    public int maxHealth;
    public int def;
    public int poisonDmg;
    public int att;
    public int baseAtt;
    public bool isDoneTurn;
    public int initiative;
    public List <BattleAbility> conditions = new List<BattleAbility>(){};
    public List <StatTypes> typeList = new List<StatTypes>(){};
    public Target targetName;
     
    //[SerializeField] Participant participant;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void setInitiative(int init){
        initiative = init;
    }

    public int getDef(){
        return def;
    }

    public int getHP(){
        return health;
    }

    public void adjustHP(int amount){
            health = (health - amount);
            isDead();
    }

    public int isHealthFull(int currenthealth){
        if (currenthealth < maxHealth ){
            return maxHealth;
        }else{
            return currenthealth;
        }
    }  

    public bool isDead(){
        return (health < 1);
    }

    public int adjustAtt(int amount){
       return (att += amount) > 1 ? (att += amount) : 1;
    }

    public void checkCurrentConditons(){

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
    }

        public void isPoisoned(){
        if (poisonDmg > 0){
            att = baseAtt -1;
            poisonDmg--;
        }
    }

     public void adjustDef(int type, int adjustment){
        if(type == 0){
            def = def + adjustment;
        }
        int [] tempStats = new int[3]{def,0,0};
        //updateStatUI(tempStats);
    }
}
