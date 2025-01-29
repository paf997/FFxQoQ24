using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : Participant{

    [SerializeField] int defMelee;
    [SerializeField] int cost;
    [SerializeField] int color;

    [SerializeField] int block;
  
    [SerializeField] int pierce;
    //public enum StatTypes  {att, attRange, attMagic, def}
    //public List <StatTypes> typeList = new List<StatTypes>(){};
    public List <int> playerStats = new List<int>(){};

    [SerializeField] string [] statUIStrings = new string [3] { "Def: ", "Att: ", "Poison: ",};
    public TextMeshProUGUI  text; 
  
    // Start is called before the first frame update
    void Start()
    {
   
       // text.text = " 0 , 0- , 0";
    }
    public bool isDead(){
        return (health < 1);
    }
    public void checkCurrentConditons(){
    }
 

    public void isPoisoned(){
    }


    void updateStatUI(int [] stats){
       string stringUICat = "";
        for (int i = 0; i < stats.Length; i++){
            stringUICat = (stringUICat + statUIStrings[i] + stats[i].ToString() + " ");
            //Debug.Log(" String CAt: " + stringUICat);
        }

        if(text!= null){
        text.text = stringUICat;
        stringUICat = "";
        }else{
            Debug.Log("Null" + text);
        }
    }

}
