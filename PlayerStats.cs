using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int buttonX = 200;
    int buttonY = 100;
    int width = 75;
    int height = 75;
    int buttonSpace;

    public GameControlScript gcs;
    public PlayerStats stats;
    public int startingHP = 12;
    public int currentHP;
    public int speed = 5;
    //public int pwr;
    public int attDMG = 3;
    public int def;
    public int initDEF;
    public int bonuses = 0;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        currentHP = startingHP;
        gcs = GameObject.FindGameObjectWithTag("ButtonMgr").GetComponent<GameControlScript>();
        def = 2;
        buttonSpace = width;
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
            adjustment = (adjustment < def) ? 0 : (adjustment-def);
            currentHP = (currentHP - adjustment);
            if(currentHP <= 0){
                currentHP = 0;
                Debug.Log("Player has died");
                isDead();
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

    public bool isDead(){
       return (currentHP < 0) ?  true :  false;
    }
    void OnGUI(){
        if(GUI.Button(new Rect (buttonX, buttonY, width, height), "Attack" + " ")){
            //Debug.Log("Test successful");
            attDMG = 2;
            
        }

        if(GUI.Button(new Rect ((buttonX+buttonSpace), buttonY, width, height), "Defense" + " ")){
            def = def+1;
        }

        if(GUI.Button(new Rect (buttonX + (buttonSpace*2), buttonY,  width, height), "Att Bonus" )){

        }

        if(GUI.Button(new Rect (buttonX + (buttonSpace*3), buttonY,  width, height), "Def Bonus" )){

        }
        if(GUI.Button(new Rect (buttonX + (buttonSpace*4), buttonY,  width, height), "Item" )){

        }
        
    }

}
