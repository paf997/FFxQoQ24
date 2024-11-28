using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]public class ReportAction : ScriptableObject
{
    public bool isAttMelee = false;
    
    [SerializeField] bool isDef = false;
    [SerializeField] int mAttacks = 1;
    [SerializeField] int attackerDMG;
    [SerializeField] EnemyBase activeEnemy;
    [SerializeField] string invokeString = "doAction";
    public bool isPreActions = false;
    public bool isPostActions = false;

    void Start()
    {
        //battleController bc = battleController.GetComponent<BattleController>();
    }
    void Update()
    {
       // if(isDef) prePlayerActions();
        //if(isPostActions) postPlayerActions();
    }

    public void setEnemyBase(EnemyBase enemy){
        activeEnemy = enemy;
        Debug.Log("setEnemyBase");
    }

    public void doAction(int adjustment){
        
    }

    public void attack(int attckDMG){

    }

    public void prePlayerActions(){
        //Invoke(invokeString, 0);
        //activeEnemy.adjustDef();
        isPreActions = false;
    }

   public void postPlayerActions(PlayerStats targetPlayer){
        //Invoke(invokeString, 0);
        //activeEnemy.getBaseDmg();
        for (int m = 0; m < mAttacks; m++){
            Debug.Log("Post player Stats " + m);
            targetPlayer.adjustHP(activeEnemy.getBaseDmg(), 0);
        }   
            isPostActions = false;
            
    }
}
