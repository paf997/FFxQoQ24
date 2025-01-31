using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenUI : MonoBehaviour
{
    [Header("Token Data")]
    [SerializeField] Token Token;
    [SerializeField] int value;
    [SerializeField] TMP_Text valueTextUI;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject Image;
    [SerializeField] TokenColor color;
    [SerializeField] StatTypes type;    
    [SerializeField] StatTypes subType; 

    [Header("UI Elements")]

    public bool isAvailable = true;     // Whether the token is available for use
    public bool isDrawn;        // Whether the token has been drawn
    public bool isExtinguishable; // Whether the token can be extinguished

    private void Start()
    {
        UpdateTokenUI();
        getDataFromSOAndSet(Token);
    }

    /// <summary>
    /// Updates the UI elements based on the assigned Token ScriptableObject.
    /// </summary>
    /// 
    public void getDataFromSOAndSet(Token data){
        //Token = data;
        Image image;
        image = data.Sprite.GetComponent<Image>();
        sprite = image.sprite;
        value = data.value;
        valueTextUI.text = value.ToString();
        type = data.type;
        color = data.color;
        subType = data.subType;
    }
    private void UpdateTokenUI()
    {
        if (Token == null)
        {
            Debug.LogWarning("No Token assigned to TokenUI.");
            return;
        }else{

        }

    }


    public void RefreshUI()
    {
        UpdateTokenUI();
    }

    public Token getTSO(){
        return Token;
    }
}
