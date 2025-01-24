using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public int cost;
    public int color;

    public int block;
    public int att;
    public int poison;
    public int pierce;
    public int heal;
    public int health = 8;
    public int maxHealth = 8;
    public int dmgMelee = 2;
    public int defMelee = 2;
    [SerializeField] Sprite enemySprite;

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
