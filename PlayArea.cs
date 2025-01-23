using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{

    [Header("Player Info")]       
    [SerializeField] PlayerInfo player;
    [SerializeField] CardCanvas cardCanvas;
    CardCanvas playerHand;
    
    [Header("Enemy Info")]
    [SerializeField] EnemyInfo target;
    void Start()
    {
        playerHand = cardCanvas.GetComponent<CardCanvas>();
    }

    void getPlayedCardInfo(GameObject playedCard){
        PlayerCardUI cardStats = playedCard.GetComponent<PlayerCardUI>();

    }
}
