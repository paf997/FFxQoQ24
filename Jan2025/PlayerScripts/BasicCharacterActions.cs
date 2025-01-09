using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterActions : MonoBehaviour
{
    public int att = 2;
    public int attAdj;
    public int dmg;
    public int redCnt = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BasicAttack(){
        AttAdj();
        dmg = att + attAdj;
        Debug.Log("Attack = " + dmg);
    }

    public void AttAdj(){
        if(redCnt == 2) attAdj = 1;
        if(redCnt > 2)  attAdj = 2;
    }


}
