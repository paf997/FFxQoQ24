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
        instatiateCollection(TokenDataList);
    }

    void instatiateCollection(List <Token> list ){
        Debug.Log("Instantiate Collection");
        if (list[0] is Token){
           // Debug.Log("Is token List");
        }else {
            //Debug.Log("Is Card List");    
        }
        foreach (Token token in list){
            GameObject newToken = Instantiate (tokenPrefab, tempTransform.position , Quaternion.identity, tempTransform );
            //Debug.Log(" the name" + newToken.name);
            newToken.GetComponent<TokenUI>().getDataFromSOAndSet(token);
            //tempTransform.position = new Vector2 (tempTransform.position.x + 50, tempTransform.position.y);
            playerBag.startingTokens.Add(newToken);
        }
    }
}
