using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCardUI : MonoBehaviour
{
    [Header("Card Data")]
    [SerializeField] private PlayerCardSO card;
    
    public int handIndex;

    [Header("UI Elements")]
    /*[SerializeField] private Image backgroundImage;
    [SerializeField] private Image foregroundImage;*/
    public TMP_Text costText;
    public bool isDrawn;        // Whether the token has been drawn
    public bool isExtinguishable; // Whether the token can be extinguished
    public GameObject cardBackgroundImg;
    public GameObject cardIconImg;
    public GameObject cardColorImg;
    private CardCanvas playerHand;

    private Sprite sprite;
    public bool isEmpty;
    public bool isAvailable;
    public GameObject cardCanvas;
    public GameObject playerDeckScript;
    private PlayerDeck playerDeck;  
    public GameObject cardOutline;
    public Outline cardAvailable;
    public Outline cardUnavailable; 
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
    }

    private void Start()
    {
        //UpdateCardUI();
        playerHand = cardCanvas.GetComponent<CardCanvas> ();
        playerDeck = playerDeckScript.GetComponent<PlayerDeck>(); 

        //Debug.Log("Type of ob = " + cardAvailable.effectColor);
        //cardAvailable.effectColor = new Color(.2000f, .050f, 1.0f, .80f);
    }

    private void uploadAvailabilityColors(){
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

    /// <summary>
    /// Updates the UI elements based on the assigned Token ScriptableObject.
    /// </summary>
    public PlayerCardSO UpdateCardUI(PlayerCardSO chosen)
    {
        Image img;
        //Debug.Log("PlayerCardUI");
        card = chosen;
        // playerDeck.removeCard();
        // Update background color
        if (card.cardBackgroundImg != null)
        {}

        // Update foreground image (optional, based on token type)
        if (card.cardActionIcon != null)
        {
            img = cardIconImg.GetComponent<Image>();
            img.sprite = card.cardActionIcon;
            //Debug.Log("Not Empty!");
        }else{
            Debug.Log("Empty");
        }
        if (card.cardCostIcon != null)
        {
            img = cardColorImg.GetComponent<Image>();
            img.sprite = card.cardCostIcon;
            //Debug.Log("Not Empty!");
        }

        if (card.cost != null)
        {
            costText.text = card.cost.ToString();
            cost = card.cost;
        }

        return card;
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
