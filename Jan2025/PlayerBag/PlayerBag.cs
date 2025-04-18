using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerBag : MonoBehaviour
{
    [Header("Token info")]
    [SerializeField]
    public int focus;
    public int drawMax;
    public int nTokens;
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
    public List <int> purpleValues = new List<int>() { 1 };
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
    [SerializeField] GameObject PlayArea;
    [SerializeField] List <int> currentTokenValues = new List<int>() {};
    [SerializeField] int initiative;
    [SerializeField] PlayArea battleCoordinator;
    [SerializeField] GameObject FocusContainer;
    [SerializeField] List <GameObject> ATBList = new List<GameObject>();
    public TokenColor tokenColor;
    [SerializeField] bool hasBusted;
    [SerializeField] GameObject TokenDiscardArea;

    public void Start (){
        initializeTokensInfo();
        tokenCanvas = TC.GetComponent<TokenCanvas>();
        playerHand = cardCanvas.GetComponent<CardCanvas>();
        battleCoordinator = PlayArea.GetComponent<PlayArea>();
        initiative = -1;
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

    public void drawButton (int temp = 3){
        if (isPrimed == 0){
            Debug.Log("Prime Action " + isPrimed);
            ShuffleTokens();
            PrimeAction();
            isPrimed++;
            tokenCanvas.updateFocusTokens(focus);
        } else if(isPrimed <= focus){
            Debug.Log("Complete Action " + isPrimed);
            DrawAction();
            isPrimed++;
        } else {
            Debug.Log("Clear Amounts/End Turn " + isPrimed);
            battleCoordinator.addInitiative(initiative);
            tokenCanvas.updateInitiativeUI(initiative);
            ClearDrawnToken();
            battleCoordinator.getInitiatives();
        }
        tokenCanvas.UpdateTokenVals(whiteTotal, whiteDrawn, redTotal, redDrawn, blueTotal, blueDrawn, yellowTotal, yellowDrawn,
        orangeTotal, orangeDrawn,greenTotal, greenDrawn, purpleTotal, purpleDrawn, wildTotal, wildDrawn);
        playerHand.CurrentTokenValues[0] = whiteDrawn;
        playerHand.CurrentTokenValues[1] = redDrawn;
        playerHand.CurrentTokenValues[2] = blueDrawn;
        playerHand.CurrentTokenValues[3] = yellowDrawn;
        playerHand.CurrentTokenValues[4] = orangeDrawn;
        playerHand.CurrentTokenValues[5] = purpleDrawn;
        playerHand.CurrentTokenValues[6] = greenDrawn;
        playerHand.CurrentTokenValues[7] = wildDrawn;

        if(playerHand.CurrentTokenValues[0] > 7){
            hasBusted = true;
        }
    
    }
    public void PrimeAction(){
        for (int i = 0;i < 3;i++){
            drawnToken = startingTokens[i].GetComponent<TokenUI>();
            Token tokenSO = drawnToken.getTSO();
            drawnToken.isDrawn = true;
            nTokens++;
            //Debug.Log("" + tokenSO.color + ": " + tokenSO.value);
            adjustTokenValues(drawnToken);
            }  
    }  
    public void DrawAction(){

        for (int i = 0;i < drawCnt;i++){
            if(hasBusted){
                Debug.Log(" Can't draw more tokens because of bust");
                break;
            }else{
                drawnToken = startingTokens[nTokens + i].GetComponent<TokenUI>();
                Token tokenSO = drawnToken.getTSO();
                drawnToken.isDrawn = true;
                Debug.Log("cnt: " + (drawCnt+ i) + " " + tokenSO.color + ": " + tokenSO.value);
                nTokens++;
                adjustTokenValues(drawnToken);
                //Debug.Log("Update prime action then update Playable Cards");
                playerHand.UpdatePlayableCards();
            }
        }  
    }
        public void ClearDrawnToken(){
        for (int i = 0;i < startingTokens.Count;i++){
            drawnToken = startingTokens[i].GetComponent<TokenUI>();
            Token tokenSO = drawnToken.getTSO();
            if(drawnToken.isDrawn){
                TokenDiscardArea.GetComponent<TokenDiscardArea>().addTokenToDiscardArea(startingTokens[i]);
                drawnToken.isDrawn = false;
            }
            //adjustTokenValues(drawnToken);?
        }
            isPrimed = 0;
            nTokens = 0;
    }
    public void FocusButtonToDrawTokens(){
        if((nTokens < (drawMax - drawCnt)) && isPrimed > 0){
            //Debug.Log("ntokens: " + nTokens +  " draw count: " + drawCnt + " draw max- drawCnt: " + (drawMax - drawCnt));
            drawButton(nTokens);
            drawCnt += nTokens;
            focus--;
        }else{
            Debug.Log("ntokens: " + nTokens +  " draw count: " + drawCnt + " draw max- drawCnt: " + (drawMax - drawCnt));
            Debug.Log("Not enough drawing");
        }
        tokenCanvas.updateFocusTokens(focus);
    }
    public int calcInitiative(){
        for (int i = 0; i < playerHand.CurrentTokenValues.Length; i++) {
            initiative += playerHand.CurrentTokenValues[i];
        }
        return initiative;
    }
    public int adjustInitiative(int value){
        initiative += value;
        return initiative;
    }

    public void adjustTokenValues(TokenUI token){
        int value = token.getTokenValue();

        if((token.getTokenColor()) == TokenColor.white){
            whiteDrawn = whiteDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.red){
            redDrawn = redDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.blue){
            blueDrawn = blueDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.yellow){
            yellowDrawn = yellowDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.green){
            greenDrawn = greenDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.purple){
            purpleDrawn = purpleDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.orange){
            orangeDrawn = orangeDrawn + value;
        }else if ((token.getTokenColor()) == TokenColor.wild){
            wildDrawn = wildDrawn + value;
        }
        placeTokenOnATB(token); 
    }

    public void placeTokenOnATB(TokenUI token){
        RectTransform posATB = token.GetComponent<RectTransform>();
        Debug.Log("Transform token" + posATB);
        adjustInitiative(token.getTokenValue()); 
        float newX = ATBList[initiative].GetComponent<RectTransform>().position.x;
        float newY = ATBList[initiative].GetComponent<RectTransform>().position.y;
        float newZ = ATBList[initiative].GetComponent<RectTransform>().position.z;
       // Debug.Log("Transform  ATB" + ATBList[0].GetComponent<RectTransform>());
        posATB.position = new Vector3(newX, newY, newZ);
        //posATB.Translate(newX, newY, newZ);
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
