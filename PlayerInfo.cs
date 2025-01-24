using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour{
    [SerializeField] int health;
    [SerializeField] int defMelee;
    [SerializeField] int maxHealth;
    [SerializeField] int cost;
    [SerializeField]  int color;

    [SerializeField] int block;
    [SerializeField]  int att;
    [SerializeField] int poison;
    [SerializeField] int pierce;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void adjustDef(int type, int adjustment){
        if(type == 0){
            defMelee = defMelee + adjustment;
        }
    }

    
}
