using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCanvas : MonoBehaviour
{
    public List <GameObject> handOrder = new List<GameObject>();
    public List <PlayerCardSO> CardsInHand = new List<PlayerCardSO>();
    public List <PlayerCardSO> CardsInDiscardPile = new List<PlayerCardSO>();
    public int handMax = 4;
    public int handCnt;
    public int discardCnt = 0;

    private PlayerCardUI card;
    private GameObject PlayerCardUIScript;
    public int [] CurrentTokenValues = new int [8];
    //[SerializeField] List <int>  = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        handCnt = CardsInHand.Count;
    }

    public void UpdateHandUI(PlayerCardSO chosen){
            activatePlayerHandUI(handCnt);
            card = handOrder[handCnt].GetComponent<PlayerCardUI>();
            PlayerCardSO completeCard = card.UpdateCardUI(chosen);
            CardsInHand.Add(completeCard);
            updateCardCounts();
            UpdatePlayableCards();
    }

    public void UpdatePlayableCards(/*int white = 0 , int red = 0; int blue = 0, int green = 0, int yellow = 0, int purple = 0*/){
        int cost = 0;
        int color = 0;
        
        for (int i = 0; i < CardsInHand.Count; i++){
            cost = CardsInHand[i].cost;
            color =  CardsInHand[i].colorCosts;

            if (isCardPlayable(cost, color)){
                //Debug.Log("Playable " + CardsInHand[i].name + "color cost = " + color + " " + CurrentTokenValues[color]);
                card.cardAvailable.enabled = true;
                card.cardUnavailable.enabled = false;
                //card.cardUnavailable.SetActive(false);
            }else{
                //Debug.Log("NOT PLAYABLE!! " + CardsInHand[i].name);
                //card.cardAvailable.SetActive(false);
                card.cardUnavailable.enabled = true;
                card.cardAvailable.enabled = false;
            }
        }
    }

    private bool isCardPlayable(int cost, int color){
        return (cost <= color);
    }

    //todo
    public void discardCardAtPos(){
        for (int i = 0; i < handOrder.Count; i++){
            Debug.Log(" i is " + i + " " + handOrder[i].name);
            DraggableUI discardedCard = handOrder[i].GetComponent<DraggableUI>();
            if (handOrder[i].active  &&  discardedCard.isDiscarded){
                Debug.Log("Discard cards at pos" + i  + " " + discardedCard);
                CardsInDiscardPile.Add(CardsInHand[i]);
                CardsInHand.RemoveAt(i);
            }
            updateCardCounts();
        }
        //CardsInHand.Remove(cardPos);
        //Debug.Log(" DiscardCardT Pos" + cardPos);
    }
    
    public void discardAllCards(){
        for (int i = 0; i < CardsInHand.Count; i++){
            discardCardAtPos();
        }
    }

    void updateCardCounts(){
        handCnt = CardsInHand.Count;
        discardCnt = CardsInDiscardPile.Count;
    }

    private bool isHandFull(){
        return (CardsInHand.Count < handMax);
    }

    private void deactivatePlayerHandUI(int cardPos){
        handOrder[cardPos].SetActive(false);
    }
    private void activatePlayerHandUI(int cardPos){
        handOrder[cardPos].SetActive(true);
    }

}
