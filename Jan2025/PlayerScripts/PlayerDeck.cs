using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class PlayerDeck : MonoBehaviour
{

    public List <PlayerCardSO> playerDeck = new List<PlayerCardSO>();
    public List <GameObject> playerDeck2 = new List<GameObject>();
    public int deckSize = 1;
    public int deckCnt;
    public int discardCnt = 0;
    public int drawNum = 1;
    public int startingCards = 2;
    [SerializeField] private PlayerCardSO chosenCard;
    [SerializeField] private GameObject chosenCard2;
    public GameObject cardCanvas;
    private CardCanvas playerHand;
    public TMP_Text discardTxt;
    public TMP_Text deckTxt;
    public  Transform handIndex; 
    public GameObject playerCardPreFab;


    public void Start (){
        playerHand = cardCanvas.GetComponent<CardCanvas> ();
        deckSize = playerDeck.Count;
        discardCnt = 0;
        deckCnt = deckSize - discardCnt;
        discardTxt.text = discardCnt.ToString();
        deckTxt.text = deckCnt.ToString(); 
        ShuffleDeck();
        instatiateDeck();
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
            //playerHand.UpdatePlayableCards(chosenCard.cost);
            discardCnt++;
            discardTxt.text = discardCnt.ToString();
            deckTxt.text = playerDeck.Count.ToString();
        } else{
            Debug.Log("Hand is Full");
        }  
    }

    void instatiateDeck(){
        Debug.Log("Instantiate");
        GameObject newCard;
        for (int i = 0; i < deckSize; i++){
            newCard = Instantiate (playerCardPreFab, handIndex.position, Quaternion.identity, handIndex);
            playerDeck2.Add(newCard);
            PlayerCardUI card = newCard.GetComponent<PlayerCardUI>();
            card.UpdateCardUI(playerDeck[i]);
        }
    }

    public void drawCards (int nCards = 1){
        if(playerHand.handCnt < playerHand.handMax){
            //Debug.Log("playerDeck");
            
            chosenCard2 = playerDeck2[0];
            playerDeck2.RemoveAt(0);
            //playerHand.UpdateHandUI(chosenCard);
            //playerHand.UpdatePlayableCards(chosenCard.cost);
            deckTxt.text = playerDeck2.Count.ToString();
        } else{
            Debug.Log("Hand is Full");
        }  
    }

    public void availableCardsInHand(){
        for (int i = 0; i < playerHand.handCnt; i++){
           
        }
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

