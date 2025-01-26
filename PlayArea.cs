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

    public List <GameObject> playedCards = new List<GameObject>();
    
    [Header("Enemy Info")]
    [SerializeField] GameObject enemyTarget;
    EnemyInfo target;
    void Start()
    {
        playerHand = cardCanvas.GetComponent<CardCanvas>();
        playerBag = playerBagGO.GetComponent<PlayerBag>();
        tokenCanvas = tokenCanvasGO.GetComponent<TokenCanvas>();
        target = enemyTarget.GetComponent<EnemyInfo>();
        battleCanvas = BattleCanvasGO.GetComponent<BattleCanvas>();
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
