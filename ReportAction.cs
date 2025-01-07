using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]public class ReportAction : ScriptableObject
{
    public bool isAttMelee = false;
    
    [SerializeField] int def;
    [SerializeField] int mAttacks = 1;
    [SerializeField] int attackerDMG;
    [SerializeField] EnemyBase activeEnemy;
    //[SerializeField] string invokeString = "doAction";
    [SerializeField] int poison;

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
        
        if(isAttMelee)
            for (int m = 0; m < mAttacks; m++){
            Debug.Log("Post player Stats " + m);
            targetPlayer.adjustHP(activeEnemy.getBaseDmg(), 0);
        } 

        if(poison > 0) { 
            targetPlayer.poisonPlayer(poison);
            }

        isPostActions = false;    
    }

    public void setDefense(MonsterStats monsterStats){
        if(def > 0){
            
        }
    }

    public int getDef(){
        return def;
    }
}
