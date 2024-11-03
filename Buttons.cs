using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

int buttonX = 50;
int buttonY = 110;
int width = 75;
int height = 75;

int buttonSpace;
    // Start is called before the first frame update
    void Start()
    {
        buttonSpace = width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI(){
        if(GUI.Button(new Rect (buttonX, buttonY, width, height), "Attack" + " ")){
            Debug.Log("Test successful");
        }

        if(GUI.Button(new Rect ((buttonX+60), buttonY, width, height), "Defense" + " ")){

        }
        
    }
}
