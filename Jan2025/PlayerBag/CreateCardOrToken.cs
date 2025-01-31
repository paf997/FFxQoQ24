using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateCardOrToken : MonoBehaviour{

[SerializeField] List<GameObject> TokenDataList = new List <GameObject> ();
[SerializeField] List<GameObject> CardDataList = new  List <GameObject> ();
public Token token;
public PlayerCardUI card;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void instatiateCollection(List <GameObject> list ){
        Debug.Log("Instantiate Collection");
        
        }
}
