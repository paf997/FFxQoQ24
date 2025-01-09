using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundButtonScript : MonoBehaviour
{

    public TMP_Text roundButtonTxt;
    public int round = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateButtonTxt(){
        round++;
        roundButtonTxt.text = round.ToString();
    }

}
