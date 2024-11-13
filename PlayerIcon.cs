using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerIcon : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpIcon;
    [SerializeField] PlayerStats ps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUpStats(){
        hpIcon.text = ps.startingHP.ToString();
    }

    public void attAction(){
        int dmgDealt = ps.attDMG;
    }
}
