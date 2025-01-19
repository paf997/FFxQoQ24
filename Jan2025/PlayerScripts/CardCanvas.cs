using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCanvas : MonoBehaviour
{
    public List <GameObject> handOrder = new List<GameObject>();
    public List <PlayerCardSO> CardsInHand = new List<PlayerCardSO>();
    public int handMax = 4;
    public int handCnt = 0;
    private PlayerCardUI card;
    private GameObject PlayerCardUIScript;
    public int [] CurrentTokenValues = new int [3];
    //[SerializeField] List <int>  = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void UpdateHandUI(PlayerCardSO chosen){
            handOrder[handCnt].SetActive(true);
            card = handOrder[handCnt].GetComponent<PlayerCardUI>();
            PlayerCardSO completeCard = card.UpdateCardUI(chosen);
            CardsInHand.Add(completeCard);
            handCnt++;
            UpdatePlayableCards();
    }

    public void UpdatePlayableCards(/*int white = 0 , int red = 0; int blue = 0, int green = 0, int yellow = 0, int purple = 0*/){
        for (int i = 0; i < CardsInHand.Count; i++){
            if (CardsInHand[i].cost <= CurrentTokenValues[2]){
                Debug.Log("Playable " + CardsInHand[i].name);
                card.cardAvailable.enabled = true;
                //card.cardUnavailable.SetActive(false);
            }else{
                Debug.Log("NOT PLAYABLE!!");
                //card.cardAvailable.SetActive(false);
                card.cardUnavailable.enabled = true;
            }
        }
    }






}
