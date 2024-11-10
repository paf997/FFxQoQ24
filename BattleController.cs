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
    List <GameObject> initiative = new List<GameObject>();
    [SerializeField] GameObject [] battlePositions2 = new GameObject [4];
    SpriteRenderer enemySprite;
    //[SerializeField] BattlePos [] battlePositions2;


        void Start()
    {
        //battlePositions2 = FindObjectsOfType<battlePos>();
       // players = GameObject.FindGameObjectsWithTag("Player");
       for (int i = 0;i < battlePositions2.Length;i++){
            GameObject position = battlePositions2[i];
            /*SpriteRenderer sprite = position.GetComponent<SpriteRenderer>();
            sprite.enabled = true;
            sprite = enemySprite; */
            //image = position.GetComponent<Image>();

           
       }


    }

    void Update()
    {
        
    }

    public void setUpBattle(){
        if (!hasBattleStarted){
            hasBattleStarted = true;
            int nEnemies = Random.Range(1,4);
            Debug.Log("Monsters = " + nEnemies);
            int enemy;
            for (int i = 0;i < nEnemies; i++){
                enemy = Random.Range(0,enemiesInArea.Count);
                Debug.Log(enemiesInArea[enemy].name);
                enemiesInArea[enemy].SetActive(true);
                enemiesInArea[enemy].transform.position = battlePositions2[i].transform.position;
            }
        }
        //initiative.AddRange(players);
        //initiative.AddRange(enemiesInBattle);
    }
}
