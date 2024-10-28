using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnStats : MonoBehaviour
{
    public StartButton startButton;
    [SerializeField]
    private TextMeshProUGUI text;
     GameObject [] statDisplays;
    
    void Start()
    {
        startButton = GameObject.FindGameObjectWithTag("ButtonMgr").GetComponent<StartButton>();
        statDisplays = GameObject.FindGameObjectsWithTag("DisplayTurnStats");
    }

    // Update is called once per frame
    void Update()
    {}

    public void updateTurnStats(int power, int redCnt, int blueCnt, int whiteCnt, int yellowCnt){
        foreach(var dts in statDisplays){
            text = dts.GetComponent<TextMeshProUGUI>();
            if(dts.name == "PowerStatDisplay"){text.text = power.ToString();}
            if(dts.name == "RedStatDisplay"){text.text = redCnt.ToString();}
            if(dts.name == "BlueStatDisplay"){ text.text = blueCnt.ToString();}
            if(dts.name == "WhiteStatDisplay"){text.text = whiteCnt.ToString();}
            if(dts.name == "YellowStatDisplay"){text.text = yellowCnt.ToString();}
            //if(db.name == "DisplayBox"){db.text = power.ToString()}
            
        }
        
    }
}
