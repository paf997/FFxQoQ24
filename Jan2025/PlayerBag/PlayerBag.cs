using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class PlayerBag : MonoBehaviour
{
    [Header("Token info")]
    [SerializeField]
    public List <GameObject> startingTokens = new List<GameObject>();
    public List <int> whiteValue = new List<int>() { 1,1,1,1,2,2,4 };
    public int whiteCnt;
    public int whiteDrawn = 0;
    public int whiteTotal;
    public List <int> redValues = new List<int>() { 1,2 };
    public int redCnt;
    public int redDrawn = 0;
    public int redTotal;
    public List <int> blueValues = new List<int>() { 1,2 };
    public int blueCnt;
    public int blueDrawn = 0;
    public int blueTotal;
    public List <int> greenValues = new List<int>() { 1 };
    public int greenCnt;
    public int greenDrawn = 0;
    public int greenTotal;
    public List <int> yellowValues = new List<int>() { 1 };
    public int yellowCnt;
    public int yellowDrawn = 0;
    public int yellowTotal;
    public List <int> orangeValues = new List<int>() { 1 };
    public int orangeCnt;
    public int orangeDrawn = 0;
    public int orangeTotal;
    public List <int> purpleValues = new List<int>() {  1};
    public int purpleCnt;
    public int purpleDrawn = 0;
    public int purpleTotal;
    public List <int> wildValues = new List<int>() {  };
    public int wildCnt;
    public int wildDrawn = 0;
    public int wildTotal;
    public int tokenMax = 20;
    public int drawCnt = 5;
    [Header("Non token info")]
    public TokenUI drawnToken;
    public GameObject TC;
    TokenCanvas tokenCanvas;
    public int isPrimed = 0;
    public GameObject cardCanvas;
    CardCanvas playerHand;
    
     [SerializeField] List <int> currentTokenValues = new List<int>() {};

    public void Start (){
        initializeTokensInfo();
        tokenCanvas = TC.GetComponent<TokenCanvas>();
        playerHand = cardCanvas.GetComponent<CardCanvas>();
    }
    
    public void ShuffleTokens()
    {
        for (int i = 0; i < startingTokens.Count; i++)
        {
            int randomIndex = Random.Range(0, startingTokens.Count);
            GameObject temp = startingTokens[i];
            startingTokens[i] = startingTokens[randomIndex];
            startingTokens[randomIndex] = temp;
        }
            tokenMax = startingTokens.Count;
            //Debug.Log("Player Bag" + tokenMax);
    }

    public void drawButton (){
        if (isPrimed == 0){
            Debug.Log("Prime Action " + isPrimed);
            ShuffleTokens();
            PrimeAction();
            isPrimed++;
        } else if(isPrimed == 1){
            Debug.Log("Complete Action " + isPrimed);
            CompleteDrawAction();
            isPrimed++;
        } else {
            Debug.Log("Clear Amounts/End Turn " + isPrimed);
            ClearDrawnToken();
            isPrimed = 0;
        }
        tokenCanvas.UpdateTokenVals(whiteTotal, whiteDrawn, redTotal, redDrawn, blueTotal, blueDrawn, yellowTotal, yellowDrawn,
        orangeTotal, orangeDrawn,greenTotal, greenDrawn, purpleTotal, purpleDrawn, wildTotal, wildDrawn);
        CardCanvas CardCavasSC = cardCanvas.GetComponent<CardCanvas>();
        CardCavasSC.CurrentTokenValues[0] = whiteDrawn;
        CardCavasSC.CurrentTokenValues[1] = redDrawn;
        CardCavasSC.CurrentTokenValues[2] = blueDrawn;
        CardCavasSC.CurrentTokenValues[3] = yellowDrawn;
        CardCavasSC.CurrentTokenValues[4] = orangeDrawn;
        CardCavasSC.CurrentTokenValues[5] = purpleDrawn;
        CardCavasSC.CurrentTokenValues[6] = greenDrawn;
        CardCavasSC.CurrentTokenValues[7] = wildDrawn;
    
    }

    public void PrimeAction(){
        for (int i = 0;i < 3;i++){
            drawnToken = startingTokens[i].GetComponent<TokenUI>();
            Token tokenSO = drawnToken.getTSO();
            drawnToken.isDrawn = true;
            //Debug.Log("" + tokenSO.color + ": " + tokenSO.value);
            adjustTokenValues(tokenSO,true);
            }  
    }  
    public void CompleteDrawAction(){

        for (int i = 3;i < drawCnt;i++){
            drawnToken = startingTokens[i].GetComponent<TokenUI>();
            Token tokenSO = drawnToken.getTSO();
            drawnToken.isDrawn = true;
            Debug.Log("cnt: " + i + " " + tokenSO.color + ": " + tokenSO.value);
            adjustTokenValues(tokenSO,true);
            Debug.Log("Update prime action then update Playable Cards");
            playerHand.UpdatePlayableCards();
        }  
    }
        public void ClearDrawnToken(){
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
        }else if (toke.color.ToLower() == "yellow"){
            yellowDrawn = yellowDrawn + val;
        }else if (toke.color.ToLower() == "green"){
            greenDrawn = greenDrawn + val;
        }else if (toke.color.ToLower() == "purple"){
            purpleDrawn = purpleDrawn + val;
        }else if (toke.color.ToLower() == "orange"){
            orangeDrawn = orangeDrawn + val;
        }else if (toke.color.ToLower() == "wild"){
            wildDrawn = wildDrawn + val;
        }
    }

    void initializeTokensInfo(){
                whiteCnt = whiteValue.Count;
        whiteTotal = whiteValue.Sum();
        currentTokenValues.Add(whiteTotal);
        
        redCnt = redValues.Count;
        redTotal = redValues.Sum();
        currentTokenValues.Add(redTotal);

        blueCnt = blueValues.Count;
        blueTotal = blueValues.Sum();
        currentTokenValues.Add(blueTotal);

        greenCnt = greenValues.Count;
        greenTotal = greenValues.Sum();
        currentTokenValues.Add(greenTotal);

        yellowCnt = yellowValues.Count;
        yellowTotal = yellowValues.Sum();
        currentTokenValues.Add(yellowTotal);

        orangeCnt = orangeValues.Count;
        orangeTotal = orangeValues.Sum();
        currentTokenValues.Add(orangeTotal);

        greenCnt = greenValues.Count;
        greenTotal = greenValues.Sum();
        currentTokenValues.Add(greenTotal);

        purpleCnt = purpleValues.Count;
        purpleTotal = purpleValues.Sum();
        currentTokenValues.Add(purpleTotal);

        wildCnt = wildValues.Count;
        wildTotal = wildValues.Sum();
        currentTokenValues.Add(wildTotal);
    }
}
