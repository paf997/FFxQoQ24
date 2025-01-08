using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCardUI : MonoBehaviour
{
    [Header("Card Data")]
    [SerializeField] private PlayerCardSO card;
    
    public int valueIndex;

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

    

    private void Start()
    {
        //UpdateCardUI();
        playerHand = cardCanvas.GetComponent<CardCanvas> ();
        playerDeck = playerDeckScript.GetComponent<PlayerDeck> ();
    }

    /// <summary>
    /// Updates the UI elements based on the assigned Token ScriptableObject.
    /// </summary>
    public void UpdateCardUI(PlayerCardSO chosen)
    {
        Image img;

        Debug.Log("PlayerVardUI");
        card = chosen;
       // playerDeck.removeCard();

        // Update background color
        if (card.cardBackgroundImg != null)
        {
    
        }

        // Update foreground image (optional, based on token type)
        if (card.cardActionIcon != null)
        {
            img = cardIconImg.GetComponent<Image>();
            img.sprite = card.cardActionIcon;
            Debug.Log("Not Empty!");
            
        }else{
            Debug.Log("Empty");
        }

        if (card.cardCostIcon != null)
        {
            img = cardColorImg.GetComponent<Image>();
            img.sprite = card.cardCostIcon;
            Debug.Log("Not Empty!");
        }

        
        if (card.cost != null)
        {
            costText.text = card.cost.ToString();
        }
    }

    public void RefreshUI()
    {
        //UpdateCardUI();
    }

    public PlayerCardSO getPlayerCardStats(){
        return card;
    }
}
