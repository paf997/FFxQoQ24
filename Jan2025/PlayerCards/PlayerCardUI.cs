using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class PlayerCardUI : MonoBehaviour
{
    [Header("Card Data")]
    [SerializeField] private PlayerCardSO card;
    public PlayerCardSO [] cardData = new PlayerCardSO [3];
    [SerializeField] List<Token> bonusTokensForBag = new List<Token>();
    
    public int handIndex;

    [Header("UI Elements")]
    /*[SerializeField] private Image backgroundImage;
    [SerializeField] private Image foregroundImage;*/
    public TMP_Text costText;
    public bool isDrawn;        // Whether the token has been drawn
    public bool isExtinguishable; // Whether the token can be extinguished
    public GameObject cardBackgroundImg;
    public GameObject [] cardIconImg = new GameObject[3];
    public GameObject [] cardColorImg = new GameObject[3];
    public GameObject [] abilityAreas  = new GameObject[3];
    private CardCanvas playerHand;
    public int nAbilities = 1;
    public Transform originalHandPosTransform;

    private Sprite sprite;
    public bool isEmpty;
    public bool isAvailable;
    public bool isPlayable;
    public GameObject cardCanvas;
    public GameObject playerDeckScript;
    private PlayerDeck playerDeck;  
    private CardAbility abilityScript; 
    public GameObject cardOutline;
    public Outline cardAvailable;
    public Outline cardUnavailable; 
    [SerializeField] GameObject PlayAreaGO ;
    [SerializeField] List <GameObject> cardAbilities = new List<GameObject>();
    public GameObject cardAbilityScript;
    PlayArea executeAction;
    [SerializeField] Color available = new Color (.40f, .290f, 1.0f, .70f);
    [SerializeField] Color unavailable = new Color (.3f, .050f, .80f, .80f);
    [SerializeField] Color selected = new Color (.2000f, .60f, 1.0f, .10f);
    [SerializeField] Color [] availbilityColors = new Color[3];
    public int borderColorCode;
    public int cost;
    public int color;
    public int block;
    public int att;
    public int poison;
    public int pierce;
    public int heal;
    public TMP_Text CardNameText;

    [SerializeField] int abilityUses;
    [SerializeField] int abilityUseRounds;

    [SerializeField] GameObject backgroundImage;
    [SerializeField] GameObject Image;
    [SerializeField] TMP_Text valueTextUI;
    [SerializeField] GameObject TokenCanvasGO;
    [SerializeField] TokenCanvas tokenCanvas;

    //public Color [] cardAvailabilityColors = new Color{  };

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        //Outline [] outlines = cardOutline.GetComponents<Outline>();
        // Debug.Log("The # of outlines is " + outlines.Length);
        //cardAvailable = outlines[0];
        //Debug.Log("#1: " + outlines[0]);
        //cardUnavailable = outlines[1];
        //Debug.Log("#1: " + outlines[1]);
        tokenCanvas = TokenCanvasGO.GetComponent<TokenCanvas>();
    }

    private void Start()
    {
        //UpdateCardUI();
        playerHand = cardCanvas.GetComponent<CardCanvas> ();
        playerDeck = playerDeckScript.GetComponent<PlayerDeck>(); 
        executeAction = PlayAreaGO.GetComponent<PlayArea>();
        GetDataFromSOAndSet(cardData);
        

        //Debug.Log("Type of ob = " + cardAvailable.effectColor);
        //cardAvailable.effectColor = new Color(.2000f, .050f, 1.0f, .80f);
    }

    public void UpdateAllAbilityAvailability(){
        foreach (GameObject data in cardAbilities){
            CardAbility cardAbility = data.GetComponent<CardAbility>();
            cardAbility.CheckAbilityCost();
            cardAbility.UpdateAvailabilityOutline();
        }
    }
    public List<Token> GetBonusTokens()
    {
        if (bonusTokensForBag.Count > 0)
        {
            return bonusTokensForBag;
        }
        return null;
        
    }

    private void uploadAvailabilityColors()
    {
        availbilityColors[0] = available;
        availbilityColors[1] = unavailable;
        availbilityColors[2] = selected;
    }

    public void updateCardAvailabilityUI(int colorNum){

        cardAvailable.enabled = true;
        borderColorCode = colorNum;

        if (borderColorCode == 0){
            cardAvailable.effectColor = available;
        }else if(borderColorCode == 1){
            cardAvailable.effectColor = unavailable;
        }else if(borderColorCode == 2){
            Debug.Log("selected");
            cardAvailable.effectColor = selected;
        }else{
            Debug.Log("None " + borderColorCode);
            cardAvailable.enabled = false;
        }
    }

    public bool setIsPlayable(){
        isPlayable = true;
        return isPlayable;
    }

    public void executeCardAbilities(){
        //Debug.Log("Execute Card abilities");
        if(att > 0){}
        /*if(cardData.defAdjustment > 0){
            //Debug.Log("Execute -- adjDef");
            executeAction.adjustDef(0, cardData.defAdjustment);
        }*/
        if(poison > 0){}
        if(heal > 0){}
        if(heal > 0){}
    }
    /// <summary>
    /// Updates the UI elements based on the assigned Token ScriptableObject.
    /// </summary>
    public PlayerCardSO UpdateCardUI()
    {
        
        for (int i = 0; i < 3; i++){
            card = cardData[i];
            //card.cardCostIcon;

            Image img;
            //Debug.Log("PlayerCardUI");

            // playerDeck.removeCard();
            // Update background color
            if (card.cardBackgroundImg != null)
            {}

            // Update foreground image (optional, based on token type)
            if (card.cardActionIcon != null)
            {
                /*Debug.Log(card.name + "i: " + i);
                img = cardIconImg[i].GetComponent<Image>();
                img.sprite = card.cardActionIcon;
                //Debug.Log("Not Empty!");*/
            }else{
                Debug.Log("Empty");
            }
            if (card.cardCostIcon != null)
            {
                /*img = cardColorImg[i].GetComponent<Image>();
                img.sprite = card.cardCostIcon;
                //Debug.Log("Not Empty!");*/
            }

            if (card.cost != null)
            {
                /*costText.text = card.cost.ToString();
                cost = card.cost;*/
            }

            if (card.name != null)
            {
                 if(i == 0){
                    CardNameText.text = card.name;
                }else{
                    name = card.name;
                }
                
               
            }
        }

        return card;
    }

    public void GetDataFromSOAndSet(PlayerCardSO [] data){
            
        for(int i = 0; i < data.Length;i++){
            PlayerCardSO ability = data[i];
            //abilityScript.setTokenCanvasExplicitly(TokenCanvasGO);
            abilityScript = abilityAreas[i].GetComponent<CardAbility>();
            abilityScript.UpdateIcon(data[i].cardCostIcon);
            //abilityScript.TestScript();
            //Debug.Log(data[i].cardCostIcon);
            abilityScript.UpdateColorCost(data[i].colorCosts);
            abilityScript.UpdateAbilityText(data[i].description);
            abilityScript.UpdateTokenColors(data[i].tokenColor);
            //type = data.type;
            //color = data.color;
            //subType = data.subType;
        }
    }

    public void calcPlayableCards(){
    }

    public void RefreshUI()
    {
        //UpdateCardUI();
    }

    public PlayerCardSO getPlayerCardStats(){
        return card;
    }
}
