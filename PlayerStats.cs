using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public GameControlScript gcs;
    public PlayerStats stats;
    public int startingHP = 12;
    public int currentHP;
    public int speed = 5;
    //public int pwr;
    public int attDMG = 3;
    public int def;
    public int initDEF;
    public int bonuses;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        currentHP = startingHP;
        gcs = GameObject.FindGameObjectWithTag("ButtonMgr").GetComponent<GameControlScript>();

    }

    public void basicAttack(int pwr){
        int pwrCost = 3;
        Debug.Log("Player Basic Attack");
        if (pwrCost > pwr){
            Debug.Log("Not enough power");
        }else{
            pwr = pwr - pwrCost;
            string attackAction = ("basic attack: " + (attDMG + bonuses) + " cost: " + pwrCost);
            gcs.reportAction(attackAction,1 );
        }
        
    }

    public void basicDefend(){
        Debug.Log("Player Basic Defend");
    }

    public void adjustHP(int adjustment, int type){
        if(type == 0){
            Debug.Log("Player loses " + adjustment + " HP");
            currentHP = (currentHP - adjustment);
            if(currentHP <= 0){
                Debug.Log("Player has died");
            }
        }else{
            Debug.Log("Player gains " + adjustment + " HP");
            currentHP = (currentHP + adjustment);
            if(currentHP > startingHP){
                currentHP = startingHP;
                Debug.Log("Player at full health " + currentHP);
            }
        }
    }

    public void choseActions(int pwrCost, int manaCost){
        

    }

}
