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
    [SerializeField] List <GameObject> participants = new List<GameObject>();

    public List <GameObject> playedCards = new List<GameObject>();
    
    [Header("Enemy Info")]
    [SerializeField] GameObject enemyTarget;
    EnemyInfo target;
    public BattleAbility ability; 
    //public enum StatTypes  {att, attRange, attMagic, def}
    //[SerializeField] StatTypes type;

    List <BattleAbility> chosenAbilities = new List<BattleAbility>();
    [SerializeField] int activeStat;
    [SerializeField] int oppositeStat;

    void Start()
    {
        playerHand = cardCanvas.GetComponent<CardCanvas>();
        playerBag = playerBagGO.GetComponent<PlayerBag>();
        tokenCanvas = tokenCanvasGO.GetComponent<TokenCanvas>();
        battleCanvas = BattleCanvasGO.GetComponent<BattleCanvas>();
        target = enemyTarget.GetComponent<EnemyInfo>();
        //getInitiatives();
        
    }

    public void getInitiatives(){
        ability = target.getRandomAbility();
        int initiative = ability.initiative;
        Initiatives.Add(initiative);
        participants.Add(enemyTarget);
        chosenAbilities.Add(ability);
        nextInTurnOrder();
    }

    public void nextInTurnOrder(){
        Debug.Log(" next turn order");
        for (int i = 0;i < participants.Count; i++ )   {
            executeAbilities(i);
        }
    }

    public void executeAbilities(int index){
        ability = chosenAbilities[index];
        Debug.Log("Chosen ability is " + ability.name);
        for (int i = 0; i < ability.type.Count; i++){
            Debug.Log("Execute " + i + " " + ability);
            BattleAbility.StatTypes type = ability.type[i];
            activeStat = ability.adjustment[i];
            findOpposingStat(type);
        }
    }

    public void findOpposingStat(BattleAbility.StatTypes sType){
        //StatTypes convertedType = (StatTypes)System.Enum.Parse( typeof(StatTypes), type );  
        //BattleAbility.StatTypes oppStat = StatTypes.def;
        if(sType == BattleAbility.StatTypes.att){
            oppositeStat = player.getDef();
            if(compareStats(activeStat, oppositeStat) > 0){
                player.adjustHP(compareStats(activeStat, oppositeStat));
            }else{
                Debug.Log("No damage because of def " + player.getDef());
            }
        } 
    }


    public int compareStats(int val1, int val2){
        Debug.Log(" Adjsutment is " + val2 + " " +  val1 + " " + player.getHP());
        int result = (val1 - val2);
        Debug.Log("result " + result);
        return result;
    }

    public void getPlayedCardInfo(GameObject playedCard){
        Debug.Log("Get Card Info");
        PlayerCardUI cardStats = playedCard.GetComponent<PlayerCardUI>();
        cardStats.executeCardAbilities();

    }

    public void adjustDef(int type = 0, int adjustment = 0){
        Debug.Log("play area increase defense");
        player.adjustDef(0, adjustment);
        
    }
    public void AdjustTargetDef(int type = 0, int adjustment = 0){
        target.adjustDef(0, adjustment);

        //Debug.Log("play are increase defense")
    }
}
