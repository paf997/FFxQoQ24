using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int nEnemies;
    //[SerializeField] BattlePos [] battlePositions2;


    void Start(){
        nEnemies = Random.Range(1,5);
    }

    void Update()
    {
        /*if(hasBattleStarted){
            hasBattleEnded(nEnemies);
        }*/
    }

    public void setUpBattle(){
        if (!hasBattleStarted){
            hasBattleStarted = true;
            Debug.Log("Monsters = " + nEnemies);
            int enemy;
            for (int i = 0;i < nEnemies; i++){
                
                enemy = Random.Range(0,nEnemies);
                MonsterStats ms = enemiesInArea[enemy].GetComponent<MonsterStats>();
                while (ms.isAvailableForBattle == false){
                    enemy = Random.Range(0,nEnemies);
                }
                ms.isAvailableForBattle = false;
                Debug.Log("yes");
                enemiesInArea[enemy].SetActive(true);
                enemiesInArea[enemy].transform.position = battlePositions2[i].transform.position;
                initiative.Add(enemiesInArea[enemy]);
                /*while(ms.isAvailableForBattle == false){
                    //Debug.Log(enemiesInArea[enemy].name);
                    enemy = Random.Range(0,enemiesInArea.Count);
                }*/
            }
        }
        //initiative.AddRange(players);
        //initiative.AddRange(enemiesInBattle);
    }

    private void hasBattleEnded(int enemies){
        for(int i = 0;i < enemies;i++) {
            if (enemiesInArea[i].GetComponent<EnemyBase>()){
                
            }
        }
    }
}
