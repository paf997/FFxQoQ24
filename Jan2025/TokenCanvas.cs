using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TokenCanvas : MonoBehaviour
{
    public TextMeshProUGUI text; 

    public void Start()
    {
  
    }

    public void UpdateTokenVals(int whiteMax = 0, int whiteCnt = 0, int redMax = 0, int redCnt = 0,
                                int blueMax = 0, int blueCnt = 0){
  
        string vals =  $"White: {whiteCnt} / {whiteMax} | Red: {redCnt} / {redMax} | Blue:  {blueCnt} / {blueMax} ";
        text.text = vals;
    }
}
