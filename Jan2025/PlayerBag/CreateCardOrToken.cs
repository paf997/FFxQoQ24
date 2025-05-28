using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class CreateCardOrToken : MonoBehaviour
{
    [SerializeField] List<Token> TokenDataList = new List<Token>();
    [SerializeField] List<GameObject> startingTokenBag = new List<GameObject>();
    //[SerializeField] List<Card> CardDataList = new  List <Card> ();
    public Transform tempTransform;
    public Token token;
    public PlayerCardUI card;
    public GameObject tokenPrefab;
    PlayerBag playerBag;
    [SerializeField] GameObject PlayerBagGO;
    void Start()
    {
        playerBag = PlayerBagGO.GetComponent<PlayerBag>();
        //InstatiateCollection(TokenDataList);
    }

    public List<GameObject> InstatiateCollection(List<Token> list, bool isForCharacter = false)
    {
        Debug.Log("Instantiate Collection");
        /**if (list[0] is Token){
           // Debug.Log("Is token List");
        }else {
            //Debug.Log("Is Card List");    
        }*/
        Debug.Log("List length" + list.Count);
        foreach (Token token in list)
        {
            AddTokenToBag(token, true);
            Debug.Log(" In the bag" + token.color + " " + token.value);
        }
        return startingTokenBag;
    }

    public void AddTokenToBag(Token token, bool isForCharacter = false)
    {
        GameObject newToken = Instantiate(tokenPrefab, tempTransform.position, Quaternion.identity, tempTransform);
        newToken.GetComponent<TokenUI>().getDataFromSOAndSet(token);
        Debug.Log("isforCahracter: " + isForCharacter );
        if (!isForCharacter)
        {
            Debug.Log("Adding new token to player bag " + newToken.name + " : " + playerBag.startingTokens.Count);
            playerBag.startingTokens.Add(newToken);
        }
        else
        {
            Debug.Log("Startingbag createScript");
            startingTokenBag.Add(newToken);
            if (playerBag != null)
            {
                playerBag.AddTokenToPlayerBag(newToken);
            }
            
            
            Debug.Log(" bag count " + startingTokenBag.Count);
        }

    }

}
