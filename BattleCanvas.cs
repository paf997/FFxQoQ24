using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleCanvas : MonoBehaviour //UI
{
    [SerializeField] GameObject PlayerStatText;
    [SerializeField] GameObject TargetStatText;
    TMP_Text textUIPlayer; 
    TMP_Text textUIMonster; 
    [SerializeField] string [] statUIStrings = new string [3] { "Def: ", "Att: ", "Poison: ",};
    
    void Start()
    {
        textUIPlayer = GetComponent<TMP_Text>();
        textUIMonster = GetComponent<TMP_Text>();

    }

    public void updateStatUI(int [] values, int [] targetValues){
       string stringUICat = "";
        for (int i = 0; i < values.Length; i++){
            stringUICat = (stringUICat + statUIStrings[i] + values[i].ToString() + " ");
        }
        textUIPlayer.text = stringUICat;
        stringUICat = "";
        for (int i = 0; i < targetValues.Length; i++){
            stringUICat = (stringUICat + statUIStrings[i] + targetValues[i].ToString() + " ");
        }
        textUIMonster.text = stringUICat;
        stringUICat = "";
    }

}
