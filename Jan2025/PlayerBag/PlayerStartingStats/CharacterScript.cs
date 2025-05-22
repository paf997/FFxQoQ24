using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    [SerializeField] CharacterClass characterClass;
    [SerializeField] int maxHP;
    [SerializeField] int hp;
    [SerializeField] List <Token> startingTokens = new List<Token>();
    [SerializeField] List <GameObject> tokenBag = new List<GameObject>();
    [SerializeField] GameObject mainCanvas;

    CreateCardOrToken createToken;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 12;
        startingTokens = characterClass.GetStartingTokens();
        createToken = mainCanvas.GetComponent<CreateCardOrToken>();
        tokenBag = createToken.InstatiateCollection(startingTokens,true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetHP(bool isMax = false){// update later for variable return value
        if (isMax )return maxHP;
        return hp;
    }
}
