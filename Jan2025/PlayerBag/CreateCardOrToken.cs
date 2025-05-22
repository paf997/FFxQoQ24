using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateCardOrToken : MonoBehaviour{

[SerializeField] List<Token> TokenDataList = new List <Token> ();
//[SerializeField] List<Card> CardDataList = new  List <Card> ();
public Transform tempTransform;
public Token token;
public PlayerCardUI card;
public GameObject tokenPrefab;
PlayerBag playerBag;
[SerializeField] GameObject Playerbag;
    void Start()
    {
        playerBag = Playerbag.GetComponent<PlayerBag> ();
        InstatiateCollection(TokenDataList);
    }

    public List <GameObject> InstatiateCollection(List <Token> list, bool isForCharacter = false ){
        Debug.Log("Instantiate Collection");
        List <GameObject> startingTokenBag = new List<GameObject>();
        /**if (list[0] is Token){
           // Debug.Log("Is token List");
        }else {
            //Debug.Log("Is Card List");    
        }*/
        foreach (Token token in list){
            GameObject newToken = Instantiate (tokenPrefab, tempTransform.position , Quaternion.identity, tempTransform );
            //TokenUI tokenUI = newToken.GetComponent<TokenUI>();
            //Token tokenSO = tokenUI.getTSO();
            //Debug.Log(" the name" + tokenSO.name);
            newToken.GetComponent<TokenUI>().getDataFromSOAndSet(token);
            //tempTransform.position = new Vector2 (tempTransform.position.x + 50, tempTransform.position.y);
            if ( isForCharacter ){
                playerBag.startingTokens.Add(newToken);
            }else{
                startingTokenBag.Add(newToken);
            }
            //Debug.Log(" In the bag" + token.color + " " + token.value);
        }
        return startingTokenBag;
    }
}
