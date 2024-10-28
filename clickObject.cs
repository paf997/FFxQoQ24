using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("start");
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if(hit.collider != null){
                    //Debug.Log("Click!!!");
                    PrintName(hit.transform.gameObject);
                    activateToken(hit.transform.gameObject);
                }

            
        }
        
    }

    private void PrintName(GameObject go){
        Debug.Log(go.name);
        
        //Debug.Log("Click");
    }

    private void activateToken(GameObject go){
       // Debug.Log("Activated token");
        if(go.GetComponent<TextShowTest>().stats.isDrawn){
            Debug.Log("Activated token");
        }else{
            Debug.Log("Not active");
        }
    }
}
