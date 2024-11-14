using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public int maxHp;
    public int dmg;
    public List <int> attacks = new List<int>();
    public bool isAvailableForBattle;
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI defText;
    [SerializeField] TextMeshProUGUI attText;
    [SerializeField] int battlePos;
    [SerializeField] BattleController bc;

    [SerializeField] PlayerIcon playerFrame;

    void Start()
    {
        stats = GetComponent<MonsterStats>();
        gcs = GameObject.FindGameObjectWithTag("ButtonMgr").GetComponent<GameControlScript>();
        SetHP();
        isAvailableForBattle = true;
        Invoke ("actionTempHelper",2);
        
       // Invoke("adjustHP", 2.0f); for testing only
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateStats(){
        defText.text = DFS.ToString();
        attText.text = dmg.ToString();
        //return baseDFS;
    }

    public void SetHP(){
        hp = eb.getStartingHP();
        maxHp = eb.getStartingHP();
        hpSlider.maxValue = maxHp;
        hpSlider.value = hpSlider.maxValue;
    }

    public void adjustHP(int amount){
        //Debug.Log("Testing");
        //int amount = 5;
        if(amount > 0){
            hp = ((hp-amount) < 1) ? 0: ( hp - amount);
        } else{
            hp = ((hp + amount) > maxHp) ?  maxHp : (hp + amount);
        }
        //return hp;
        hpSlider.value = hp;
    }

    public void setBattlePos(int index){
        battlePos = index;
        Debug.Log("SetBattlePos Monster Stats");
    } 

    public void reportBattlePos(){
        bc.findTarget(battlePos);
    }
    public void basicAttack(){
        Debug.Log("Goblin Basic Attack. Goblin deals " + (baseDMG) + "DMG");
        actionMsg = ("Goblin Basic Attack. Goblin deals " + (baseDMG) + "DMG");
        gcs.reportAction(actionMsg, 1);
        attacks.Add((baseDMG));
        dmg = baseDMG;

        /****/
        //Debug.Log("Attacks: " + attacks.Count );
        //target.adjustHP(3*baseDMG);
    }
    public void basicDefense(){
        Debug.Log("Goblin Basic Defense. Goblin  generates" + (baseDFS) + "DFS");
        actionMsg = ("Goblin Basic Defense. Goblin  generates" + (baseDFS) + "DFS");
        gcs.reportAction(actionMsg, 1);
        /*DFS = (baseDFS);
        DFS = DFS + baseDFS; ?*/
        DFS = baseDFS *2;
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

    public void actionTempHelper(){
        Debug.Log("Action helper");
        action(1,1);
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
        updateStats();
        }
    }
}


