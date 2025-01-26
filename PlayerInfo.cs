using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour{
    [SerializeField] int health;
    [SerializeField] int defMelee;
    [SerializeField] int maxHealth;
    [SerializeField] int cost;
    [SerializeField]  int color;

    [SerializeField] int block;
    [SerializeField]  int att;
    [SerializeField] int poison;
    [SerializeField] int pierce;

    public TMP_Text text;
    [SerializeField] string [] statUIStrings = new string [3] { "Def: ", "Att: ", "Poison: ",};
    public TextMeshProUGUI text2; 
    // Start is called before the first frame update
    void Start()
    {

    }
    public bool isDead(){
        return (health < 1);
    }
    public int isHealthFull(int currenthealth){
        if (currenthealth < maxHealth ){
            return maxHealth;
        }else{
            return currenthealth;
        }
    }   

    public void adjustHP(int type, int amount){
        if (type == 0 ){//healing
            health = isHealthFull(health + amount);
        }else if(type == 1){// melee
            health = health - amount;
            isDead();
        }
    }

    public void adjustDef(int type, int adjustment){
        if(type == 0){
            defMelee = defMelee + adjustment;
        }
        int [] tempStats = new int[3]{defMelee,0,0};
        updateStatUI(tempStats);
    }

    void updateStatUI(int [] stats){
       string stringUICat = "";
        for (int i = 0; i < stats.Length; i++){
            stringUICat = (stringUICat + statUIStrings[i] + stats[i].ToString() + " ");
            Debug.Log(" String CAt: " + stringUICat);
        }

        if(text!= null){
        text.text = stringUICat;
        stringUICat = "";
        }else{
            Debug.Log("Null");
        }

    }

    
}
