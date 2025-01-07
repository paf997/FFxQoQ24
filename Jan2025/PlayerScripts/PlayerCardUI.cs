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
    public bool isAvailable = true;     // Whether the token is available for use
    public bool isDrawn;        // Whether the token has been drawn
    public bool isExtinguishable; // Whether the token can be extinguished
    public GameObject cardBackgroundImg;
    public GameObject cardIconImg;
    public GameObject cardColorImg;

    private Sprite sprite;
    

    private void Start()
    {
        UpdateCardUI();
    }

    /// <summary>
    /// Updates the UI elements based on the assigned Token ScriptableObject.
    /// </summary>
    private void UpdateCardUI()
    {
        Image img;

        if (card == null)
        {
            Debug.LogWarning("No Card assigned to TokenUI.");
            return;
        }

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

        // Update token value text
        /*if (tokenValueText != null)
        {
            tokenValueText.text = token.value.ToString();
        }*/
    }

    /// <summary>
    /// Converts a string representation of a color into a Unity Color.
    /// Defaults to white if parsing fails.
    /// </summary>
    /// <param name="colorString">The color string (e.g., "red", "blue").</param>
    /// <returns>A Unity Color.</returns>
    /*private Color GetColorFromString(string colorString)
    {
        switch (colorString.ToLower())
        {
            case "red": return Color.red;
            case "blue": return Color.blue;
            case "green": return Color.green;
            case "yellow": return Color.yellow;
            default: return Color.white; // Default color if none match
        }
    }*/

    /// <summary>
    /// Manually refreshes the UI (e.g., if the token data changes).
    /// </summary>
    public void RefreshUI()
    {
        UpdateCardUI();
    }

    public PlayerCardSO getPlayerCardStats(){
        return card;
    }
}
