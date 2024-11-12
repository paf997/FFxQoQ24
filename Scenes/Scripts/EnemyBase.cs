using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]

public class EnemyBase : ScriptableObject
{

    [SerializeField] int startingHP;
    [SerializeField] int startingDmg;
    int dmg;
    [SerializeField] int startingMDmg;
    int mDmg;
    [SerializeField] int startingRDmg;
    int rDmg;
    [SerializeField] int startingDef;
    int def;
    [SerializeField] int startingMagDef;
    int magDef;
    [SerializeField] int startingRangeDef;
    int rangeDef;
    [SerializeField] string name;
    [SerializeField] int initiative;
    [SerializeField] int attacks;
    [SerializeField] List <EnemyAttack> enemyAttacks = new List<EnemyAttack>();
    bool isFinsihed;
    private string actionMsg;
    public GameControlScript gcs;
    
 
    void Awake()
    {
        dmg = startingDmg;
        rDmg  = startingRDmg;
        mDmg = startingMDmg;
        def = startingDef;
        rangeDef = startingRangeDef;
        magDef = startingMagDef;

    }

    void Start()
    {

        randomAction();
    }

    void Update()
    {
       // randomAction();
    }

    public int getStartingHP(){
        return startingHP;
    }

    public void adjustDefense(int adjDef = 0, int adjRDef = 0, int adjMDef = 0 ){//0= att, 1 = ranged, 2 = magic 
        def = def + adjDef;
        magDef = magDef + adjMDef;
        rangeDef = rangeDef + adjRDef;

    }

    public void resetDef(int adjDef = 0, int adjRDef = 0, int adjustMDef = 0){//0= att, 1 = ranged, 2 = magic 
        if(adjDef != 0) def = startingDef;
        if(adjRDef !=0) rangeDef = startingRangeDef;
        if(adjustMDef !=0) magDef = startingMagDef;

    }

    public void adjustAttack(int attAdj = 0, int rAttAdj = 0, int mAttAdj = 0,int nAttacks = 1){
        dmg =  dmg + attAdj;
        mDmg =  dmg + mAttAdj;
        rDmg =  dmg + rAttAdj;
    }

    public void randomAction(){
        if(!isFinsihed){
            int rand = Random.Range(0,enemyAttacks.Count);  
            Debug.Log("random action: " + rand);
            switch(rand) {
                case 0:baseAttack(); break;
                case 1:baseAttack(); break;
                case 2:baseDefense(); break;
                case 3:baseDefense(); break;
                case 4:powerAttack(); break;
                case 5:specialAttack();break;
                case 6:specialAttack2();break;
                case 7:specialAttack3();break;
                case 8:specialAttack(); break;
            }
            endTurn();
        }
    }

    
    public void baseAttack(){
        
    }

    public void baseDefense(){
       
    }
    public void powerAttack(){
        
    }
    public void specialAttack(){
        
    }
    public void specialAttack2(){
        
    }
    public void specialAttack3(){
        
    }

    public void endTurn(){
        isFinsihed = true;
    }
}
