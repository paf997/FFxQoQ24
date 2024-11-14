using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerIcon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpIcon;
    [SerializeField] PlayerStats ps;
    [SerializeField] BattleController bc;
    [SerializeField] GameObject eia;
    [SerializeField] GameObject enemyTarget;
    [SerializeField] MonsterStats ms;
    public int[] targets;

    public int target;
    void Start()
    {
        targets = new int [bc.getEnemiesN()];
        setUpStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public GameObject targetEnemy(){

    }*/

    public void setUpStats(){
        hpIcon.text = ps.startingHP.ToString();
        for (int i = 0; i < targets.Length; i++){

        }
        Debug.Log("targets:" + targets.Length + "");
    }

    public void attAction(){
        //ms = eia.transform.GetChild(pos).GetComponent<MonsterStats>();
        //int pos = ms.getBattlePos();
        //target = eia.transform.GetChild(pos).GetComponent<MonsterStats>();
        int dmgDealt = ps.attDMG;
        bc.reportAction(dmgDealt);
        //ms.adjustHP(dmgDealt);
    }
}
