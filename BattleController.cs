using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleController : MonoBehaviour
{
    public bool hasBattleStarted = false;
    [SerializeField] List <GameObject> enemiesInArea = new List<GameObject>();
    //private List <EnemyBase> enemiesInBattle = new List<EnemyBase>();
    //[SerializeField] int [] battlePositions =  new int [4];
    //private List <Player> players;
    [SerializeField] List <GameObject> initiative = new List<GameObject>();
    [SerializeField] GameObject [] battlePositions2 = new GameObject [4];
    SpriteRenderer enemySprite;
    [SerializeField] int nEnemies;
    //[SerializeField] BattlePos [] battlePositions2;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] int round = 0;
    [SerializeField] int target;
    public bool hasTarget = false;
    public bool hasAction = false;
    [SerializeField] int dmg;
    [SerializeField] int dfs;
    [SerializeField] GameObject battleContainer;
    [SerializeField] PlayerStats player;
    [SerializeField] List <GameObject> offenseActions = new List<GameObject>();
    public List <ScriptableObject> actionList = new List<ScriptableObject>();
    

    void Start(){
        nEnemies = Random.Range(1,4);
        //Debug.Log("Random = " + nEnemies);
    }

    void Update()
    {
        /*if(hasBattleStarted){
            hasBattleEnded(nEnemies);
        }*/
        if(hasTarget && hasAction)  calculateResult(); 
    }

    void calculateResult(){
        hasAction = false;
        hasTarget = false;
        Debug.Log("Calculate");
        enemiesInArea[target].GetComponent<MonsterStats>().adjustHP(dmg);

    }

    public void findTarget(int reportedPos){
       // Debug.Log("FindTarget Monster Stats");
        target = reportedPos;
        hasTarget = true;
    }

    public void reportAction(int reportedDMG){
        hasAction = true;
       // Debug.Log("Report Action Monster Stats");
        dmg = reportedDMG;
    }

    public void turnsAndInitiative(){
        round++;
        turnText.text = round.ToString();
    }

    public void setUpBattle(){
        MonsterStats ms;
        if (!hasBattleStarted){
            hasBattleStarted = true;
            //Debug.Log("Monsters = " + nEnemies);
            int enemy;
            for (int i = 0;i < nEnemies; i++){
                
                enemy = Random.Range(0,nEnemies);
                ms = enemiesInArea[enemy].GetComponent<MonsterStats>();
                ms.setBattlePos(i);
                while (ms.isAvailableForBattle == false){
                    enemy = Random.Range(0,nEnemies);
                    ms = enemiesInArea[enemy].GetComponent<MonsterStats>();
                }
                ms.isAvailableForBattle = false;
                ms.action();
                //Debug.Log("yes");
                enemiesInArea[enemy].SetActive(true);
                enemiesInArea[enemy].transform.position = battlePositions2[i].transform.position;
                initiative.Add(enemiesInArea[enemy]);
                /*while(ms.isAvailableForBattle == false){
                    //Debug.Log(enemiesInArea[enemy].name);
                    enemy = Random.Range(0,enemiesInArea.Count);
                }*/
            }
        }else{
            foreach (GameObject enemy in enemiesInArea){
                ms = enemy.GetComponent<MonsterStats>();
                ms.action();

            }
        }
        turnsAndInitiative();
        //initiative.AddRange(players);
        //initiative.AddRange(enemiesInBattle);
    }

    public int getEnemiesN (){
        return nEnemies;
    }

    public void reportDeath(int pos){
        Debug.Log(enemiesInArea[pos].name + " has Died");
        enemiesInArea[pos].SetActive(false);
    }

    public void executeEnemyActions(){
        Debug.Log("Execute Actions");
        foreach(GameObject enemy in enemiesInArea){
            if(enemy.activeSelf){
                //MonsterStats currentEnemy = enemy.GetComponent<MonsterStats>();
                /*for (int i = 0; i < currentEnemy.nAttacks; i++){
                    Debug.Log(enemy.name + " dmg = " + currentEnemy.dmg);
                    player.adjustHP(currentEnemy.dmg, 0);
                }*/
                //currentEnemy.nAttacks = 1;
                ReportAction enemyAction = enemy.GetComponent<MonsterStats>().action();

                enemyAction.postPlayerActions(player);
            }
         }
    }

    private void hasBattleEnded(int enemies){
        for(int i = 0;i < enemies;i++) {
            if (enemiesInArea[i].GetComponent<EnemyBase>()){
                
            }
        }
    }
}
