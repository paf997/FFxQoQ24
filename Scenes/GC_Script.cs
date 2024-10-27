using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GC_Script : MonoBehaviour
{
    private GameObject gameController;
    private GameObject chosen;
    private Token_Stats tokenStats;
    private GameObject [] bagOfTokens;
    private int [] shuffledInts;
    public TextMeshPro text;
    private string finalString;
    private int whiteCnt = 0;
    private int blueCnt = 0;
    private int greenCnt = 0;
    private int yellowCnt = 0;
    private int redCnt = 0;
    private int totalCnt = 0;
    public int randInt = 0;
    public int bust = 6;
    public int power; 

    // Start is called before the first frame update
    void Start()
    {

    //bagOfTokens = GameObject.FindGameObjectsWithTag("Token");
    gameController = GameObject.FindGameObjectWithTag("GameController");
    //Invoke ("getTokens",1);
    //shuffledInts = randomizedInts(bagOfTokens.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*public void getTokens (){
        
        //GC_Script GCStats = gameController.GetComponent<GC_Script>();
        //text.text = "Bye Bye";
        int whiteCnt = 0;

        TextShowTest tst;
        shuffledInts = new int[bagOfTokens.Length];
        power = 0;

       for (int count = 0; count < bagOfTokens.Length; count++){
            bool repeat;
            if (whiteCnt < bust){
                do  {
                    repeat = false;
                    randInt = Random.Range(0, shuffledInts.Length);
                    tst = bagOfTokens[ randInt].GetComponent<TextShowTest>();
                    //Debug.Log("Test: " + tst.name + " " + tst.stats.color  + " " + tst.stats.Tvalue); 
                    //Debug.Log("Here are the numbers. White = " + whiteCnt + " Blue " + blueCnt + " Yellow " + yellowCnt + "Red " + redCnt);
                    if(tst.stats.isDrawn){
                        //Debug.Log("Already drawn" + bagOfTokens[count].name);
                        repeat = true;
                    }else{
                        //Debug.Log("drawing " + bagOfTokens[count].name);
                        tst.stats.isDrawn = true;
                        power = (power + tst.stats.Tvalue);
                        Debug.Log("power" + power);
                    } 
                 } while (repeat);

                    switch(tst.stats.color){
                    case "white":
                        whiteCnt = whiteCnt + tst.stats.Tvalue;
                        //Debug.Log("white");
                        break;
                    case "blue":
                        blueCnt = blueCnt + tst.stats.Tvalue;
                        break;
                    case "yellow":
                        yellowCnt = yellowCnt + tst.stats.Tvalue;
                        break;
                    case "red":
                        redCnt = redCnt + tst.stats.Tvalue;
                        break;
                    case "green":
                        greenCnt = greenCnt + tst.stats.Tvalue;
                        break;
                }
            }else{

            }
        
                
        }
        Debug.Log("Here are the numbers. White = " + whiteCnt + " Blue " + blueCnt + " Yellow " + yellowCnt + "Red " + redCnt + "total Power " + power);
    }
        

        /*public int[] randomizedInts(int bagLength){
            for (int i = 0; i < shuffledInts.Length; i++)
        {
            shuffledInts[i] = i;
            int temp = shuffledInts[i];
            int objIndex = Random.Range(0, shuffledInts.Length);
            shuffledInts[i] = shuffledInts[objIndex];
            shuffledInts[objIndex] = temp;
            Debug.Log( "pos: " + i + " = " + shuffledInts[i]);
        }
        return shuffledInts;
       }*/
}
