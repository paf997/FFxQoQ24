using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System;

public class PlayerDeck : MonoBehaviour
{

    public List <PlayerCardSO> playerDeck = new List<PlayerCardSO>();

    public List <GameObject> playerDeck2 = new List<GameObject>();
    public List <GameObject> PlayerCards = new List<GameObject>();
    public GameObject playerCard;
    public int deckSize = 2;
    public int deckCnt;
    public int discardCnt = 0;
    public int drawNum = 1;
    public int startingCards = 2;
    [SerializeField] private PlayerCardSO chosenCard;
    [SerializeField] private GameObject chosenCard2;
    public GameObject cardCanvas;
    private CardCanvas playerHand;
    public TextMeshProUGUI discardTxt;
    public TextMeshProUGUI deckTxt;
    public Transform handIndex; 
    public Transform currentHandIndex;
    [SerializeField] int handIndexSpacing = 2;

    public GameObject playerCardPreFab;

    public void Start (){
        playerHand = cardCanvas.GetComponent<CardCanvas> ();
        //deckSize = playerDeck2.Count;
        discardCnt = 0;
        deckCnt = deckSize - discardCnt;
        discardTxt.text = discardCnt.ToString();
        deckTxt.text = deckCnt.ToString(); 
        ShuffleDeck();
        instatiateDeck();
        //drawCards(5);
    }
    
    public void ShuffleDeck()
    {
        /**for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, playerDeck.Count); Random not working, but don't need it right now
            PlayerCardSO temp = playerDeck[i];
            playerDeck[i] = playerDeck[randomIndex];
            playerDeck[randomIndex] = temp;
        }*/
    }
    
    public void drawButton (){
        if(playerHand.handCnt < playerHand.handMax){
            //Debug.Log("playerDeck");
            //ShuffleDeck();
            chosenCard = playerDeck[0];
            playerCard = PlayerCards[0];
    
            playerDeck.RemoveAt(0);
            PlayerCards.RemoveAt(0);
            
            playerHand.UpdateHandUI(chosenCard);
            //playerHand.UpdatePlayableCards(chosenCard.cost);
            discardCnt++;
            if(discardTxt != null){
                //Debug.Log("Good!" + discardCnt.ToString());
                discardTxt.text = discardCnt.ToString();
            }else{
                //Debug.Log("fail!! ");
            }
            deckTxt.text = playerDeck.Count.ToString();
        } else{
            Debug.Log("Hand is Full");
        }  
    }

    void instatiateDeck(){
        Debug.Log("Instantiate");
        GameObject newCard;
        int j = 1;
        Debug.Log("Deck size: "  + deckSize);
        for (int i = 0; i < PlayerCards.Count; i++){
            currentHandIndex = playerHand.handOrder[i].transform;//change back to i later for hand 
            newCard = Instantiate (PlayerCards[i], currentHandIndex.position, Quaternion.identity, currentHandIndex);
            //newCard.SetActive(false);
            Debug.Log("Card created: " + newCard.name.ToString());
            PlayerCardUI card = newCard.GetComponent<PlayerCardUI>();
            playerDeck2.Add(newCard);
            card.UpdateCardUI();
            //deckSize = playerDeck2.Count;
        }
    }

    public void drawCards (int nCards = 5){
        //Debug.Log("playerDeck: DrawCards ");
        for (int i = 0;i < PlayerCards.Count;i++){
             //Debug.Log("i: " + i + "Is hand full?: " + playerHand.isHandFull() + isDeckEmpty() );
            if(!isDeckEmpty()){
                chosenCard2 = playerDeck2[0];
                playerDeck2.RemoveAt(0);
                int handindex = playerHand.handCnt;
                //Debug.Log("moving to hand position " + handindex );
                //playerHand.handOrder[handindex].SetActive(true);
                playerHand.handCnt++;
                Transform cardPlacement = chosenCard2.GetComponent<Transform>();
                //Debug.Log("Trans " + cardPlacement + " : " cardIn );
                cardPlacement.position = playerHand.handOrder[playerHand.handCnt].transform.position;
                PlayerCardUI card = chosenCard2.GetComponent<PlayerCardUI>();
                card.originalHandPosTransform = cardPlacement;
                
                chosenCard2.SetActive(true);
                card.handIndex = playerHand.CardsInHand2.Count;
                //Debug.Log("Adding card now in deck script "+ i + " " +  card.handIndex);
                playerHand.addCardToHandPos(chosenCard2);

               // Debug.Log(" Card index " + card.handIndex + "playerHandCard count " + playerHand.CardsInHand2.Count );
                //playerHand.UpdateHandUI(chosenCard);
                //playerHand.UpdatePlayableCards(chosenCard.cost);
                deckTxt.text = playerDeck2.Count.ToString();
            } else{
                Debug.Log("Hand is Full");
            } 
            //Debug.Log(" right after drawing cards");
            playerHand.UpdatePlayableCards();
        }     
    }

    public bool isDeckEmpty(){
        //Debug.Log("DeckSIze " + deckSize.ToString());
        return (deckSize < 1);
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

