using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    [SerializeField] CharacterClass characterClass;
    [SerializeField] int maxHP;
    [SerializeField] int hp;
    [SerializeField] List<Token> startingTokens = new List<Token>();
    [SerializeField] List<GameObject> tokenBag = new List<GameObject>();
    [SerializeField] GameObject mainCanvas;
    [SerializeField] List<GameObject> equippedItems = new List<GameObject>();

    CreateCardOrToken createToken;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 12;
        startingTokens = characterClass.GetStartingTokens();
        createToken = GetComponent<CreateCardOrToken>();
        if (startingTokens != null)
        {
            Debug.Log("Starting token Length " + startingTokens.Count);
            tokenBag = createToken.InstatiateCollection(startingTokens, true);
        }
        else
        {
            Debug.Log("Starting token Length " + startingTokens.Count);
        }
        
        if (characterClass.GetStartingGear() != null)
        {
            equippedItems = characterClass.GetStartingGear();
            CheckEquippedGear();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int GetHP(bool isMax = false)
    {// update later for variable return value
        if (isMax) return maxHP;
        return hp;
    }

    public void CheckEquippedGear()
    {
        Debug.Log("CheckingGear - charcter script");
        if (equippedItems.Count > 0)
        {
            Debug.Log("Not Null");
            foreach (GameObject item in equippedItems)
            {
                Debug.Log("Items in list" + item.name);
                if (item.GetComponent<PlayerCardUI>().GetBonusTokens() != null)
                {
                    Debug.Log("Get bonus token return value " + item.name + " " + item.GetComponent<PlayerCardUI>().GetBonusTokens());
                    foreach (Token token in item.GetComponent<PlayerCardUI>().GetBonusTokens())
                    {
                        Debug.Log("CheckingGear: " + token);
                        createToken.AddTokenToBag(token, true);
                    }
                }
                else
                {
                    Debug.Log(" No bonus tokens in list");
                }
            }
        }Debug.Log("Exiting CheckGeaR");
    }
}
