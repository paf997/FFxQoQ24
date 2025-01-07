using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerBag : MonoBehaviour
{

    [SerializeField]
    public List <GameObject> startingTokens = new List<GameObject>();
    public int tokenMax = 30;
    public int currentTokens;    
    public int redTokens;
    public int drawnRed;
    public int greenTokens;
    public int drawnGreen;
    public int blueTokens;
    public int drawnBlue;
    public int whiteTokens;
    public int drawnWhite;
    public int drawCnt = 5;
    public TokenUI drawnToken;
    
    public void ShuffleTokens()
    {
        for (int i = 0; i < startingTokens.Count; i++)
        {
            int randomIndex = Random.Range(0, startingTokens.Count);
            GameObject temp = startingTokens[i];
            startingTokens[i] = startingTokens[randomIndex];
            startingTokens[randomIndex] = temp;
        }
            tokenMax = startingTokens.Count;
            Debug.Log("Player Bag" + tokenMax);
    }

        public void PrimeAction(){
            for (int i = 0;i < 3;i++){
                drawnToken = startingTokens[i].GetComponent<TokenUI>();
                Token tokenSO = drawnToken.getTSO();
                drawnToken.isDrawn = true;
                Debug.Log("" + tokenSO.color + ": " + tokenSO.value);
            }    
    }  
            public void CompleteDrawAction(){
            for (int i = 3;i < drawCnt;i++){
                drawnToken = startingTokens[i].GetComponent<TokenUI>();
                Token tokenSO = drawnToken.getTSO();
                drawnToken.isDrawn = true;
                Debug.Log("" + tokenSO.color + ": " + tokenSO.value);
            }    
    }

    public void ClearDrawnToken(){

    }

    public void UpdateDrawnTokenTotals(){
        
    }   
}
