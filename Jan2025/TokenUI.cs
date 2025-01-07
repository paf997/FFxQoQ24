using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenUI : MonoBehaviour
{
    [Header("Token Data")]
    [SerializeField] private Token token;

    [Header("UI Elements")]
    /*[SerializeField] private Image backgroundImage;
    [SerializeField] private Image foregroundImage;*/
    public TMP_Text tokenValueText;
    public bool isAvailable = true;     // Whether the token is available for use
    public bool isDrawn;        // Whether the token has been drawn
    public bool isExtinguishable; // Whether the token can be extinguished

    private void Start()
    {
        UpdateTokenUI();
    }

    /// <summary>
    /// Updates the UI elements based on the assigned Token ScriptableObject.
    /// </summary>
    private void UpdateTokenUI()
    {
        if (token == null)
        {
            Debug.LogWarning("No Token assigned to TokenUI.");
            return;
        }

        // Update background color
        /*if (backgroundImage != null)
        {
            backgroundImage.color = GetColorFromString(token.color);
        }

        // Update foreground image (optional, based on token type)
        if (foregroundImage != null)
        {
            foregroundImage.enabled = token.isAvailable; // Example: toggle visibility based on availability
        }*/

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
        UpdateTokenUI();
    }

    public Token getTSO(){
        return token;
    }
}
