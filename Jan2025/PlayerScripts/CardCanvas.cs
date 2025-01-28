using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCanvas : MonoBehaviour
{
    public List <GameObject> handOrder = new List<GameObject>();
    public List <PlayerCardSO> CardsInHand = new List<PlayerCardSO>();
    public List <GameObject> CardsInHand2 = new List<GameObject>();
    public List <GameObject> CardsInDiscardPile = new List<GameObject>();
    public int handMax = 4;
    public int handCnt = 0;
    public int discardCnt = 0;
    [SerializeField] GameObject PlayAreaGO;
    PlayArea playArea;

    private PlayerCardUI card;
    private GameObject PlayerCardUIScript;
    public int [] CurrentTokenValues = new int [8];
    //[SerializeField] List <int>  = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        //handCnt = CardsInHand.Count;
        playArea = PlayAreaGO.GetComponent<PlayArea>();

    }

    public void UpdateHandUI(PlayerCardSO chosen){
            activatePlayerHandUI(handCnt);
            card = handOrder[handCnt].GetComponent<PlayerCardUI>();
            PlayerCardSO completeCard = card.UpdateCardUI();
            CardsInHand.Add(completeCard);
            updateCardCounts();
            UpdatePlayableCards();
    }

        public void closeCardsSpacesInHand(int index){

        }

    public void UpdatePlayableCards(/*int white = 0 , int red = 0; int blue = 0, int green = 0, int yellow = 0, int purple = 0*/){
        int cost = 0;
        int color = 0;
        Debug.Log(" updateing availabity");
        for (int i = 1; i < CardsInHand2.Count; i++){
            PlayerCardUI tempCard = CardsInHand2[i].GetComponent<PlayerCardUI>();
            cost = tempCard.cost;
            color =  tempCard.color;

            Debug.Log(" cost: " + cost + "Color: " + color);

            if (isCardPlayable(cost, color)){
                Debug.Log("Playable " + CardsInHand2[i].name + "color = " + color  + " color" + cost);
                //card.cardAvailable.enabled = true;
                //card.cardUnavailable.enabled = false;
                //card.cardUnavailable.SetActive(false);
                //Outline turnOnOutline = card.GetComponent<Rect>().Getomponent<Outline>();
                tempCard.updateCardAvailabilityUI(0);
            }else{
                tempCard.updateCardAvailabilityUI(1);
                Debug.Log("NOT PLAYABLE!! " + CardsInHand2[i].name);
                //card.cardAvailable.SetActive(false);
            }
        }
    }

    private bool isCardPlayable(int cost, int color){
        Debug.Log(" playerable " +   CurrentTokenValues[color] + "cost"  + cost);
        return (cost <= CurrentTokenValues[color]);
    }

    public void updateHandIndices(int index){
        for (int i = index; i < CardsInHand2.Count; i++) {
            GameObject cardGO = CardsInHand2[i];
            card = cardGO.GetComponent<PlayerCardUI>();
            //Debug.Log("Update Indcies before " + card.handIndex);
            card.handIndex = i;
            //Debug.Log("Update Indcies after " + card.handIndex);
            //Debug.Log(" handOrder i and i+1 " + handOrder[i].transform.position + " : " + handOrder[i +1].transform.position);
            cardGO.transform.position = handOrder[i+1].transform.position;
        }
    }
    public void discardCardAtPos(int index){
        GameObject discardedCard = CardsInHand2[index] ;
        //Debug.Log("Discarded" + discardedCard.name);
        CardsInDiscardPile.Add(discardedCard);
        card = discardedCard.GetComponent<PlayerCardUI> ();
        //Debug.Log("Card index discarded" + card.handIndex);
        discardedCard.SetActive(false);
        CardsInHand2.RemoveAt(index);
        updateHandIndices(index);
        updateCardCounts();

       /* for (int i = 0; i < handOrder.Count; i++){
            //Debug.Log(" i is " + i + " " + handOrder[i].name);
            DraggableUI discardedCard = handOrder[i].GetComponent<DraggableUI>();
            if (handOrder[i].active  &&  discardedCard.isDiscarded){
                //Debug.Log("Discard cards at pos" + i  + " " + discardedCard);
                CardsInDiscardPile.Add(CardsInHand[i]);
                CardsInHand.RemoveAt(i);
            }
            updateCardCounts();
        }*/
        //CardsInHand.Remove(cardPos);
        //Debug.Log(" DiscardCardT Pos" + cardPos);
    }

    public void putCardInPlayArea(int cardIndex){
        Debug.Log("Put in play are ---- CardIndex" + cardIndex);
        GameObject tempCard = CardsInHand2[cardIndex];
        if(tempCard.GetComponent<PlayerCardUI>().isAvailable){
            playArea.playedCards.Add(tempCard);
            discardCardAtPos(cardIndex);
            playArea.getPlayedCardInfo(tempCard);
        }else{
            Debug.Log("Card is unavailable");

        }
    }

    public void putCardBackInHand(GameObject tempCard){
        Debug.Log ("putting card back");
    }
    
    public void discardAllCards(){
        for (int i = 1; i < CardsInHand.Count; i++){
            discardCardAtPos(i);
        }
    }

    public void addCardToHandPos(GameObject cardToAdd){
        card = cardToAdd.GetComponent<PlayerCardUI> ();
        if(card.isAvailable){
            CardsInHand2.Add(cardToAdd);
            card.handIndex = CardsInHand2.Count -1;
        }else{  
            cardToAdd.transform.position = card.originalHandPosTransform.position;

        }
        //Debug.Log("CardCanvas/PlayerCard: " + card.handIndex );
    }

    void updateCardCounts(){
        handCnt = CardsInHand2.Count;
        discardCnt = CardsInDiscardPile.Count;
    }

    public bool isHandFull(){
         //Debug.Log("Cards in HAnd Count " +  CardsInHand.Count);
        return (CardsInHand.Count > handMax);
    }

    private void deactivatePlayerHandUI(int cardPos){
        handOrder[cardPos].SetActive(false);
    }
    private void activatePlayerHandUI(int cardPos){
        handOrder[cardPos].SetActive(true);
    }

}
