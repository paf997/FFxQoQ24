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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateIcon(Sprite data){
        if(abilityButton.GetComponent<Image>().sprite == null){
            //Debug.Log(" Is null");
        }else{
            abilityButton.GetComponent<Image>().sprite = data;
            //Debug.Log("not null");
        }
    }

    public void UpdateColorCost(string data){
        valueTextUI.text = data;
    }

    public void UpdateAbilityText(string data){
        abilityTextUI.text = data;
    }

    public void TestScript(){
        Debug.Log (" Test Script !!!");
    }

}
