using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{

    [Header("Player Info")]       
    [SerializeField] PlayerInfo player;
    [SerializeField] CardCanvas cardCanvas;
    [SerializeField] GameObject tokenCanvasGO;
    TokenCanvas tokenCanvas;
    [SerializeField] GameObject playerBagGO;
    PlayerBag playerBag;
    CardCanvas playerHand;
    
    [Header("Enemy Info")]
    [SerializeField] EnemyInfo target;
    void Start()
    {
        playerHand = cardCanvas.GetComponent<CardCanvas>();
        playerBag = playerBagGO.GetComponent<PlayerBag>();
        tokenCanvas = tokenCanvasGO.GetComponent<TokenCanvas>();
        
    }

    void getPlayedCardInfo(GameObject playedCard){
        PlayerCardUI cardStats = playedCard.GetComponent<PlayerCardUI>();

    }
}
