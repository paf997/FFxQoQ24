using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{

    [Header("Player Info")]       
    [SerializeField] PlayerInfo player;
    [SerializeField] int defMelee;
    [SerializeField] CardCanvas cardCanvas;
    [SerializeField] GameObject tokenCanvasGO;
    BattleCanvas battleCanvas;
    TokenCanvas tokenCanvas;
    [SerializeField] GameObject BattleCanvasGO;
    [SerializeField] GameObject playerBagGO;
    [SerializeField] int cost;
    [SerializeField]  int color;

    [SerializeField] int block;
    [SerializeField]  int att;
    [SerializeField] int poison;
    [SerializeField] int pierce;
    PlayerBag playerBag;
    CardCanvas playerHand;
    GameObject Card;

    int [] statValues = new int [3]{0,0,0};
    int [] targetStatValues = new int [3]{0,0,0};
    [SerializeField] List <int> Initiatives = new List<int>();
    [SerializeField] List <Participant> participants = new List<Participant>();

    public List <GameObject> playedCards = new List<GameObject>();
    
    [Header("Enemy Info")]
    [SerializeField] GameObject enemyTarget;
    EnemyInfo enemy;
    public BattleAbility ability; 
    //public enum StatTypes  {att, attRange, attMagic, def}
    //[SerializeField] StatTypes type;

    List <BattleAbility> chosenAbilities = new List<BattleAbility>();
    [SerializeField] int activeStat;
    [SerializeField] int oppositeStat;
    Participant activeParticipant;

    void Start()
    {
        playerHand = cardCanvas.GetComponent<CardCanvas>();
        playerBag = playerBagGO.GetComponent<PlayerBag>();
        tokenCanvas = tokenCanvasGO.GetComponent<TokenCanvas>();
        battleCanvas = BattleCanvasGO.GetComponent<BattleCanvas>();
        enemy = enemyTarget.GetComponent<EnemyInfo>(); 
    }

    public void getInitiatives(){
       for (int i = 0;  i < participants.Count; i++)
            if (participants[i].targetName == Target.player1 ){
                Debug.Log ("player initiative  already added");
            }else{
                enemy = participants[i].GetComponent<EnemyInfo>();
                ability = enemy.getRandomAbility();
                int initiative = ability.initiative;
                Initiatives.Add(initiative);
                //participants.Add(enemyTarget);
                chosenAbilities.Add(ability);
        }
        nextInTurnOrder();
    }

    public void addInitiative(int init){
        Initiatives.Add(init);
    }

    public void nextInTurnOrder(){
        Debug.Log(" next turn order");
        for (int i = 0;i < participants.Count; i++ )   {
            executeAbilities(i);
        }
    }

    public void executeAbilities(int index){
        activeParticipant = enemy;
        ability = chosenAbilities[index];
        Debug.Log("Chosen ability is " + ability.name);
        for (int i = 0; i < ability.type.Count; i++){
            Debug.Log("Execute " + i + " " + ability);
            StatTypes type = ability.type[i];
            activeStat = ability.adjustment[i];
            findOpposingStat(type,activeParticipant);
        }
    }

    public void findOpposingStat(StatTypes sType, Participant target){
        //StatTypes convertedType = (StatTypes)System.Enum.Parse( typeof(StatTypes), type );  
        //BattleAbility.StatTypes oppStat = StatTypes.def;
        if(sType == StatTypes.att){
            oppositeStat = player.getDef();
            if(compareStats(activeStat, oppositeStat) > 0){
                player.adjustHP(compareStats(activeStat, oppositeStat));
            }else{
                //Debug.Log("No damage because of def " + player.getDef());
            }
        }else if(sType == StatTypes.def){
            activeStat = enemy.getDef();
            Debug.Log("Def is stype" );
            //adjustDef(0,activeStat,enemy);
        }else if (sType == StatTypes.poison){
            applyCondition(determineTarget(ability.target), activeStat);
        }
    }


    public int compareStats(int val1, int val2){
        //Debug.Log(" Adjsutment is " + val2 + " " +  val1 + " " + player.getHP());
        int result = (val1 - val2);
        Debug.Log("result " + result);
        return result;
    }

    public void getPlayedCardInfo(GameObject playedCard){
        Debug.Log("Get Card Info");
        PlayerCardUI cardStats = playedCard.GetComponent<PlayerCardUI>();
        cardStats.executeCardAbilities();

    }

    public void adjustDef(int type, int adjustment, Participant target){
        Debug.Log("Type " + typeof(Participant));
        if(type == 0){
           // target.def = target.def + adjustment;
        }
        int [] tempStats = new int[3]{defMelee,0,0};
        //updateStatUI(tempStats);
    }

    public void adjustAtt(int type, int adjustment, Participant targe){
        Debug.Log("Type " + typeof(Participant));
        if(type == 0){
           // target.def = target.def + adjustment;
        }
        int [] tempStats = new int[3]{defMelee,0,0};
        //updateStatUI(tempStats);
    }

    public void AdjustTargetDef(int type = 0, int adjustment = 0){
        //adjustDef(0, adjustment);

        //Debug.Log("play are increase defense")
    }

    public Participant determineTarget(Target target){
        return (target == Target.player1 ? player : enemy);
    }
    public void applyCondition(Participant target, int adjustment){
        target.conditions.Add(ability);
    }
}
