using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class PlayerDeck : MonoBehaviour
{

    public List <PlayerCardSO> playerDeck = new List<PlayerCardSO>();
    public int deckSize;
    public int deckCnt;
    public int discardCnt = 0;
    public int drawNum = 1;
    public int startingCards = 2;
    [SerializeField] private PlayerCardSO chosenCard;
    public GameObject cardCanvas;
    private CardCanvas playerHand;
    public TMP_Text discardTxt;
    public TMP_Text deckTxt;

    public void Start (){
        playerHand = cardCanvas.GetComponent<CardCanvas> ();
        deckSize = playerDeck.Count;
        discardCnt = 0;
        deckCnt = deckSize - discardCnt;
        discardTxt.text = discardCnt.ToString();
        deckTxt.text = deckCnt.ToString();
    }
    
    public void ShuffleDeck()
    {
        for (int i = 0; i < playerDeck.Count; i++)
        {
            int randomIndex = Random.Range(0, playerDeck.Count);
            PlayerCardSO temp = playerDeck[i];
            playerDeck[i] = playerDeck[randomIndex];
            playerDeck[randomIndex] = temp;
        }
    }
    
    public void drawButton (){
        if(playerHand.handCnt < playerHand.handMax){
            //Debug.Log("playerDeck");
            ShuffleDeck();
            chosenCard = playerDeck[0];
            playerDeck.RemoveAt(0);
            playerHand.UpdateHandUI(chosenCard);
            discardCnt++;
            discardTxt.text = discardCnt.ToString();
            deckTxt.text = playerDeck.Count.ToString();
        } else{
            Debug.Log("Hand is Full");
        }  
    }

    public void availableCardsInHand(){
        
    }

    public void removeCard(){
        playerDeck.RemoveAt(0);
    }

 

  /*      public void ClearDrawnToken(){
        for (int i = 0;i < drawCnt;i++){
            drawnToken = startingTokens[i].GetComponent<TokenUI>();
            Token tokenSO = drawnToken.getTSO();
            drawnToken.isDrawn = false;
            adjustTokenValues(tokenSO, false);
        }
    }

    public void adjustTokenValues(Token toke, bool isIncrease){
        int val = toke.value;
        if(!isIncrease) {val = (toke.value * -1);}

        if(toke.color == "white"){
            whiteDrawn = whiteDrawn + val;
        }else if (toke.color.ToLower() == "red"){
            redDrawn = redDrawn + val;
        }else if (toke.color.ToLower() == "blue"){
            blueDrawn = blueDrawn + val;
        }
        
    }*/
 
}

