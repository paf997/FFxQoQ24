using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundButtonScript : MonoBehaviour
{

    public TextMeshProUGUI roundButtonTxt;
    public int round = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateButtonTxt(string text){
        roundButtonTxt.text = round.ToString();
        //round++;
    }

    public void endPhase(){

    }

}
