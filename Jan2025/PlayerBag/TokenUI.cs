using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenUI : MonoBehaviour
{
    [Header("Token Data")]
    [SerializeField] Token token;
    [SerializeField] int value;
    [SerializeField] TMP_Text valueTextUI;
    //[SerializeField] Sprite sprite;
    [SerializeField] GameObject backgroundImage;
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
        //UpdateTokenUI();
        //getDataFromSOAndSet(Token);
       //Debug.Log("type === " + sprite.name );
    }
    public void getDataFromSOAndSet(Token data){
        token = data;
        backgroundImage.GetComponent<Image>().sprite = data.backgroundImage;
        Image.GetComponent<Image>().sprite = data.battleImage;
        value = data.value;
        valueTextUI.text = data.value.ToString();
        type = data.type;
        color = data.color;
        subType = data.subType;
    }
    private void UpdateTokenUI()
    {
        if (token == null)
        {
            Debug.LogWarning("No Token assigned to TokenUI.");
            return;
        }else{
        }
    }
    public int getTokenValue(){
        return value;
    }

    public TokenColor getTokenColor(){
        return color;
    }
    public void RefreshUI()
    {
        UpdateTokenUI();
    }

    public Token getTSO(){
        return token;
    }
}
