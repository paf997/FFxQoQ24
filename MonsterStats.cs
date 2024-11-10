using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    public EnemyBase eb;
    public MonsterStats stats;
    public int baseDMG = 3;
    public int baseDFS = 2;
    public int DFS;
    public int randomAction;
    public string actionMsg;
    public GameControlScript gcs;
    public int hp;
    public int maxHp = 8;
    public int dmg;
    public List <int> attacks = new List<int>();
    public bool isAvailableForBattle;

    void Start()
    {
        stats = GetComponent<MonsterStats>();
        gcs = GameObject.FindGameObjectWithTag("ButtonMgr").GetComponent<GameControlScript>();
        hp = eb.hp;
        isAvailableForBattle = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void basicAttack(){
        Debug.Log("Goblin Basic Attack. Goblin deals " + (baseDMG) + "DMG");
        actionMsg = ("Goblin Basic Attack. Goblin deals " + (baseDMG) + "DMG");
        gcs.reportAction(actionMsg, 1);
        attacks.Add((baseDMG));
        //Debug.Log("Attacks: " + attacks.Count );

        //target.adjustHP(3*baseDMG);
    }
    public void basicDefense(){
        Debug.Log("Goblin Basic Defense. Goblin  generates" + (baseDFS) + "DFS");
        actionMsg = ("Goblin Basic Defense. Goblin  generates" + (baseDFS) + "DFS");
        gcs.reportAction(actionMsg, 1);
        DFS = (baseDFS);
        DFS = DFS + baseDFS;
    }
    public void poisonAttack(){
        Debug.Log("Goblin Poison Attack. Goblin deals " + "1 " + "Poison");
        actionMsg = ("Goblin Poison Attack. Goblin deals " + "1 " + "Poison");
        gcs.reportAction(actionMsg, 1);
    }
    public void powerAttack(){
        Debug.Log("Goblin Power Attack. Goblin deals " + (2*baseDMG) + "DMG");
        actionMsg =("Goblin Power Attack. Goblin deals " + (2*baseDMG) + "DMG");
        gcs.reportAction(actionMsg, 1);
        attacks.Add((2*baseDMG));
        //Debug.Log("Attacks: " + attacks.Count );
    }
    public void resetStats(){
        DFS = 0;
        dmg = 0;
    }

    public void action(int nActions,int nEnemies = 1){
        int action = Random.Range(0,nActions);
        for(int i = 0; i<nEnemies; i++){

            switch(action){
            case 0:
                basicAttack();
                basicAttack();
                //Debug.Log("white");
                break;
            case 1:
                basicDefense();
                basicAttack();
                break;
            case 2:
                basicDefense();
                basicDefense();
                //poisonAttack();
                break;
            case 3:
                powerAttack();
                basicDefense();
                //poisonAttack();
                break;
            case 4:
                powerAttack();
                //basicDefense();
                //basicAttack();
                break;
            default:
                Debug.Log("Nothing Happens");
                break;
            }
        }
    }
}


