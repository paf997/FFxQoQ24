using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : Participant
{

    [SerializeField] CharacterClass characterClass;
    [SerializeField] List<Token> startingTokens = new List<Token>();
    [SerializeField] List<GameObject> tokenBagTokens = new List<GameObject>();
    [SerializeField] GameObject mainCanvas;
    [SerializeField] List<GameObject> equippedItems = new List<GameObject>();
    [SerializeField] GameObject tokenBagGO;
    private PlayerBag playerBag;
    [SerializeField] Button initiativeIconBtn;
    [SerializeField] GameObject initiativeScaleGO;
    private IntitiativeScale intitiativeScale;
    
    CreateCardOrToken createToken;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = characterClass.GetMaxHP();
        startingTokens = characterClass.GetStartingTokens();
        createToken = GetComponent<CreateCardOrToken>();
        intitiativeScale = initiativeScaleGO.GetComponent<IntitiativeScale>();
        if (startingTokens != null)
        {
            Debug.Log("Starting token Length " + startingTokens.Count);
            tokenBagTokens = createToken.InstatiateCollection(startingTokens, true);
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

        playerBag = tokenBagGO.GetComponent<PlayerBag>();
        playerBag.startingTokens = tokenBagTokens;
        playerBag.SetBagText(characterClass.name.ToString());
        Debug.Log("copied bags " + playerBag.startingTokens.Count);
    }

    public void SetTurnInitiative(int data)
    {
            initiative = data;
            intitiativeScale.AddParticipantInitiative(this);
    }

    public Button GetInitiativeIcon()
    {
        return initiativeIconBtn;
    }
    public void ClearInitiative()
    {
        initiative = 0;
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
        }
        Debug.Log("Exiting CheckGeaR");
    }

}
