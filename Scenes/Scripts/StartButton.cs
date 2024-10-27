using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartButton : MonoBehaviour
{
    private int chosen;
    private Token_Stats tokenStats;
    private GameObject [] bagOfTokens;
    private List <int> shuffledInts = new List<int>();
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
    public Button button;
    private TextShowTest tst;


    // Start is called before the first frame update
    void Start()
    {

    bagOfTokens = GameObject.FindGameObjectsWithTag("Token");
    createRandomChoices();
    //StartTurn sstartTurn = GameObject.FindGameObjectWithTag("StartTurn");

    //button.onClick.AddListener(startTurn);
    //gameController = GameObject.FindGameObjectWithTag("GameController");
    //Invoke ("getTokens",1);
    //shuffledInts = randomizedInts(bagOfTokens.Length);
    }

    // Update is called once per frame
    public void OnDestroy(){
      // button.onClick.RemoveListener(startTurn);
        //Debug.Log("on destroy");
        endTurn();
    }

    public void endTurn(){
        whiteCnt = 0; 
        blueCnt = 0;
        redCnt = 0;
        yellowCnt = 0;
        greenCnt = 0;
        power = 0;
        Debug.Log("Here are the numbers. White = " + whiteCnt + " Blue " + blueCnt + " Yellow " + yellowCnt + "Red " + redCnt + "total Power " + power);
        for (int i = 0; i < bagOfTokens.Length; i++){
            tst = bagOfTokens[i].GetComponent<TextShowTest>();
            tst.stats.isDrawn = false;
        }
        createRandomChoices();

    }

    private void createRandomChoices(){
        for (int count = 0; count < bagOfTokens.Length; count++){
            shuffledInts.Add(count+1);
            //Debug.Log("adding: " + count+1 + " shuflledInts = " + shuffledInts.Count);
        }
    }

    public void startTurn (){
    
        //GC_Script GCStats = gameController.GetComponent<GC_Script>();
        //text.text = "Bye Bye";
        int whiteCnt = 0;
        power = 0;

       for (int count = 0; count < bagOfTokens.Length; count++){
            bool repeat;
            if (whiteCnt < bust){
                //do  {
                    repeat = false;
                    randInt = Random.Range(0, shuffledInts.Count);
                    //Debug.Log("bag length = " + bagOfTokens.Length);
                    chosen = bagOfTokens.Length - shuffledInts[randInt];
                    //Debug.Log("Chosen = " + chosen);
                    //Debug.Log("the random number is " + randInt);
                    tst = bagOfTokens[chosen].GetComponent<TextShowTest>();
                    //Debug.Log("# of ints = " + (shuffledInts.Count-1) + " renadom int = " + (bagOfTokens.Length - shuffledInts[randInt]));
                    //Debug.Log("Test: " + tst.stats.name + " " + tst.stats.color  + " " + tst.stats.Tvalue + "randInt = " + randInt + " count" + " number of ints = " + shuffledInts.Count); 
                    if(tst.stats.isDrawn){
                        Debug.Log("randInt = " + randInt + " whiteCount = " + whiteCnt + " name = " + tst.stats.name);
                        Debug.Log("Already drawn" + tst.stats.name);
                        repeat = true;
                    }else{
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
                        //Debug.Log("drawing " + bagOfTokens[chosen].name);
                        tst.stats.isDrawn = true;
                        power = (power + tst.stats.Tvalue);
                       // Debug.Log("Tvalue = " + tst.stats.Tvalue);
                        //Debug.Log("power " + power + " colr:" + tst.stats.color);
                        shuffledInts.RemoveAt(randInt);
                        //Debug.Log("After removing " + tst.stats.name + " " + shuffledInts.Count);
                        for (int i = 0; i < shuffledInts.Count-1; i++){
                            // Debug.Log("#: " + i + " ints left = " + shuffledInts[i]);
                            //Debug.Log ("Added. Number of ints left = " + shuffledInts.Count);
                         }
                    } 
                // } while (repeat);
                //Debug.Log("Here are the numbers. White: " + whiteCnt + " Blue: " + blueCnt + " Yellow: " + yellowCnt + "Red: " + redCnt);
            //}else{

           // }
        
            //Debug.Log("cnt:  " + count);  
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


    //public Button startTurn; //start turn and draw chips

    /*private void Start(){
        startButton.onClick.AddListener(startTurn);
    }

    private void OnDestroy(){
        startButton.onClick.RemoveListener(startTurn);
    }*/


    }}

