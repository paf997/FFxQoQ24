using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextShowTest : MonoBehaviour
{
    private GameObject token;
    public TextMeshPro text;
    private string tokenColor = "red";
    public Token_Stats stats;

    public int retrievedTValue;
    public string retrievedColor;

    // Start is called before the first frame update
    void Start()
    {

        stats = GetComponent<Token_Stats>();
        retrievedTValue =  getTValue();
        retrievedColor = getTColor();
        /*text.text = stats.Tvalue.ToString();*/
    
    }

    // Update is called once per frame
    void Update()
    {
    }  

    public int getTValue(){
        //Debug.Log("token value in show text = " + this.stats.name + "name: " + this.stats.Tvalue);
        return stats.Tvalue;
    }

        public string getTColor(){
        //Debug.Log("color " + stats.color);
        return stats.color;
    }
    
}
