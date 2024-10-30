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
    public TextMeshProUGUI playerDisplay;
    public GameObject enemyDisplay;
    public TextMeshProUGUI text;
   // public GameObject
    void Start()
    {
        playerOb = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Monster");
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
        PlayerStats player = playerOb.GetComponent<PlayerStats>();
        playerDisplay.text = player.currentHP.ToString();
    }

    public void reportAction
    (string actionStr, int action){
        //PlayerStats player = playerOb.GetComponent<PlayerStats>();
        //StartButton startButton = buttMgr.GetComponent<StartButton>();
        text.text = actionStr;
            //adjust player and monster stats
            //do player actions --> just update using strings(see next step), player and monsters will do their own updating
            //display actions
            //update displays for stats using update stats from character
    
    }
}
