using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardAbility : MonoBehaviour
{
    [SerializeField] GameObject backgroundImage;
    [SerializeField] GameObject abilityButton;
    [SerializeField] TMP_Text valueTextUI;
    [SerializeField] TMP_Text abilityTextUI;
    [SerializeField] int cost;
    [SerializeField] TokenColor tokenColor;
    public bool isAvailable;
    [SerializeField] GameObject TokenCanvas;
    private TokenCanvas tokenCanvas; 


    // Start is called before the first frame update
    void Start()
    {
        tokenCanvas = TokenCanvas.GetComponent<TokenCanvas>();
    }

    public void UpdateIcon(Sprite data){
        if(abilityButton.GetComponent<Image>().sprite == null){
            //Debug.Log(" Is null");
        }else{
            abilityButton.GetComponent<Image>().sprite = data;
            //Debug.Log("not null");
        }
    }
    public void UpdateColorCost(int data){
        if(data == null){
            //Debug.Log(" Is null");
        }else{
            valueTextUI.text = data.ToString();
            cost = data;
            //Debug.Log("not null");
        } 
    }
    public void UpdateAbilityText(string data){
        if(data == null){
            //Debug.Log(" Is null");
        }else{
            abilityTextUI.text = data;
            //Debug.Log("not null");
        } 
    }

    public void UpdateTokenColors(TokenColor data){
        if(data == null){
            //Debug.Log(" Is null");
        }else{
            tokenColor = data;
            CheckAbilityCost();
            //Debug.Log("not null");
        } 
    }

    public bool CheckAbilityCost(){
        return (cost <= tokenCanvas.getColorValue(tokenColor));
    }


    public void TestScript(){
        Debug.Log (" Test Script !!!");
    }
}
