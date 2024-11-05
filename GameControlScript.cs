using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControlScript : MonoBehaviour
{
    public GameObject playerOb;
    public GameObject enemy;
    public GameObject buttMgr;
    public GameObject battleDisplay;
    public GameObject enemyUpdates;
    public TextMeshProUGUI playerDisplay;
    public GameObject enemyDisplay;
    public TextMeshProUGUI text;
    public TextMeshProUGUI monsterDisplay;
    public PlayerStats player;
    public MonsterStats monsterStats;
   // public GameObject
    void Start()
    {
        playerOb = GameObject.FindGameObjectWithTag("Player");
        player = playerOb.GetComponent<PlayerStats>();
        enemy = GameObject.FindGameObjectWithTag("Monster");
        monsterStats = enemy.GetComponent<MonsterStats>();

        monsterDisplay = GameObject.FindGameObjectWithTag("EnemyDisplay").GetComponent<TextMeshProUGUI>();
        StartButton startTurn = GetComponent<StartButton>();
        battleDisplay = GameObject.FindGameObjectWithTag("BattleDisplay");
        text = battleDisplay.GetComponent<TextMeshProUGUI>();
        playerDisplay = GameObject.FindGameObjectWithTag("PlayerDisplay").GetComponent<TextMeshProUGUI>();
        updateStats();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateStats(){
        playerDisplay.text = ("HP:" + player.currentHP.ToString() + " DEF:" + player.def.ToString());
        //Debug.Log ("The def: "  + player.def.ToString());
        MonsterStats mdText = enemy.GetComponent<MonsterStats>();
        monsterDisplay.text = ("HP:" + mdText.hp.ToString() + " DEF:" + mdText.DFS.ToString());
        
    }

    public void reportAction
    (string actionStr, int action){
        updateStats();
        //PlayerStats player = playerOb.GetComponent<PlayerStats>();
        //StartButton startButton = buttMgr.GetComponent<StartButton>();
        text.text = actionStr;
        endPlayerTurn();
            //adjust player and monster stats
            //do player actions --> just update using strings(see next step), player and monsters will do their own updating
            //display actions
            //update displays for stats using update stats from character

    }

    public void endPlayerTurn(){
        Debug.Log("Player HP" + player.currentHP.ToString());
        for (int i = 0; i < monsterStats.attacks.Count; i++){
            player.adjustHP(monsterStats.attacks[i],0);
            Debug.Log("Player HP" + player.currentHP.ToString());
            monsterStats.attacks.RemoveAt(i);
        }
        updateStats();
        
    }
}
