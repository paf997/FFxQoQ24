using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnStats : MonoBehaviour
{
    public StartButton startButton;

     [SerializeField]
     private TextMeshProUGUI text;
    
    void Start()
    {
        startButton = GameObject.FindGameObjectWithTag("ButtonMgr").GetComponent<StartButton>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {}

    public void updateTurnStats(string update){
        text.text = update;
        
    }
}
