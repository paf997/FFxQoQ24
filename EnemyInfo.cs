using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : Participant
{
    public int initiative;
    public int block;
    public int att;
    public int poison;
    public int pierce;
    public int heal;
    public int health = 8;
    public int maxHealth = 8;
    public int def;
    public List <int> adjustments = new List<int>(){};
    [SerializeField] Sprite enemySprite;
    [SerializeField] List <BattleAbility> abilityList;
    public BattleAbility ability; 
    public List <StatTypes> typeList = new List<StatTypes>(){};
    public List <BattleAbility> conditions = new List<BattleAbility>(){};
    public void checkCurrentConditons(){
    }

    // Start is called before the first frame update
    void Start()
    {
       /* ability = abilityList[0];
        Debug.Log(" Ability: " + ability.adjustment[i]);*/
    }

    public BattleAbility getRandomAbility(){
        int total = 0;
        Debug.Log("Ability List Count " + abilityList.Count);
        for (int i = 0; i < abilityList.Count; i++){
            ability = abilityList[i];
            total += ability.probability;
            //Debug.Log("Probability = " + total);
        }
        int index = Random.Range(0, abilityList.Count);
        return abilityList[index];
    }

    public bool isDead(){
        return (health < 1);
    }
    public int isHealthFull(int currenthealth){
        if (currenthealth < maxHealth ){
            return maxHealth;
        }else{
            return currenthealth;
        }
    }   

    public void adjustHP(int type, int amount){
        if (type == 0 ){//healing
            health = isHealthFull(health + amount);
        }else if(type == 1){// melee
            health = health - amount;
            isDead();
        }
    }
    public int getDef(){
        return def;
    }

}
