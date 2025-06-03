using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;


public class TokenCanvas : MonoBehaviour
{
    public TextMeshProUGUI text; 
    [SerializeField] List <GameObject> FocusListUI = new List<GameObject>();
    [SerializeField] int focus = 0;
    [SerializeField] bool powerTotalsHaveChanged;

    [SerializeField] GameObject CardCanvasGO;


    public void Start()
    {
        //updateFocusTokens(2);//test call
    }

    int whiteMax = 0;
     int whiteCnt = 0; 
     int redMax = 0; 
     int redCnt = 0;
    int blueMax = 0;
    int blueCnt = 0;
    int yellowMax = 0; 
    int yellowCnt = 0;
    int orangeMax = 0; 
    int orangeCnt = 0;
    int greenMax = 0; 
    int greenCnt = 0;
                                
    int purpleMax = 0;
    int purpleCnt = 0;
    int wildMax = 0;
    int wildCnt = 0;
    [SerializeField] int initiative = 0;

  public void Awake()
  {
    initiative = 0;
  }

  public void UpdateTokenVals(int whiteValueMax = 0, int whiteValueCnt = 0, int redValueMax = 0, int redValueCnt = 0,
                                int blueValueMax = 0, int blueValueCnt = 0,int yellowValueMax = 0, int yellowValueCnt = 0,
                                int orangeValueMax = 0, int orangeValueCnt = 0,int greenValueMax = 0, int greenValueCnt = 0,
                                int purpleValueMax = 0, int purpleValueCnt = 0,int wildValueMax = 0, int wildValueCnt = 0){

        whiteMax = whiteValueMax;
        whiteCnt = whiteValueCnt;
        redMax = redValueMax;
        redCnt = redValueCnt;
        blueMax = blueValueMax;
        blueCnt = blueValueCnt;
        yellowMax = yellowValueMax;
        yellowCnt = yellowValueCnt;
        orangeMax = orangeValueMax;
        orangeCnt = orangeValueCnt;
        greenMax = greenValueMax;
        greenCnt = greenValueCnt;
        purpleMax = purpleValueMax;
        purpleCnt = purpleValueCnt;
        wildMax = wildValueMax;
        wildCnt = wildValueCnt;

        initiative = whiteCnt + redCnt + greenCnt + yellowCnt + blueCnt + orangeCnt  + purpleCnt + wildCnt;
        string vals =  $"Red: {redCnt} / {redMax} | Green:  {greenCnt} / {greenMax} | Yellow:  {yellowCnt} / {yellowMax }| blue:  {blueCnt} / {blueValueMax }| White: {whiteCnt} / {whiteMax}| Initiative: " + initiative;
        text.text = vals;
        

        CardCanvas playerHand = CardCanvasGO.GetComponent<CardCanvas>();
        playerHand.GetCardsInHand();
        
    }

    public int getAvailableRedPower(){
        return redCnt;
    }

    public int getAvailableBluePower(){
        return blueCnt;
    }
    public int getAvailableWhitePower(){
        return whiteCnt;
    }

    public int getAvailableOrangePower(){
        return orangeCnt;
    }
    public int getAvailableGreenPower(){
        return greenCnt;
    }
    public int getAvailableYellowPower(){
        return yellowCnt;
    }

    public int getAvailablePurplePower(){
        return purpleCnt;
    }

    public int getAvailableWildPower(){
        return wildCnt;
    }

    public int getTotalInitiativeCnt(){
        //Debug.Log("getTotalInitiativeCnt");
        return initiative;
    }

    public int getColorValue(TokenColor data){

        if(data == TokenColor.white){
            return getAvailableWhitePower();
        }else if(data == TokenColor.red){
            return getAvailableRedPower();
        }else if(data == TokenColor.blue){
            return getAvailableBluePower();
        }else if(data == TokenColor.yellow){
            return getAvailableYellowPower();
        }else if(data == TokenColor.orange){
            return getAvailableOrangePower();
        }else if(data == TokenColor.green){
            return getAvailableGreenPower();
        }else if(data == TokenColor.purple){
            return getAvailablePurplePower();
        }else{
            return getAvailableWildPower();
        }  
    }
    public void updateInitiativeUI(int init){

    }

    public int getFocusCount(){
        return focus;
    }

    public bool getPowerTotalsHaveChanged(){
        return powerTotalsHaveChanged;
    }

    private void setPowerTotalsHaveChanged(){
        //Debug.Log("setPowerTotalHaveChanged");
        powerTotalsHaveChanged = !powerTotalsHaveChanged;
    }
    
    public void updateFocusTokens(int data){
        Debug.Log("UpdateFocus");
        GameObject focusButton;
        focus = data;
        for(int i = 0; i < FocusListUI.Count; i++) {
            focusButton = FocusListUI[i];
            if(i < data){
                focusButton.SetActive(true);
            }else{
                focusButton.SetActive(false);
            }    
        }   
    }
}
