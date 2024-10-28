using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Token_Stats : MonoBehaviour
{
    public int Tvalue;
    [SerializeField] public string color;
    public bool isDrawn = false;

    public GameObject backOutline;
    public Token_Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Token_Stats>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isActiveToken(bool answer){
        if(isDrawn){
            Debug.Log("Token is active");
        }
        backOutline.SetActive(answer);
    }

}
