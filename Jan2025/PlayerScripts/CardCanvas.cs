using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCanvas : MonoBehaviour
{
    public List <GameObject> handOrder = new List<GameObject>();
    public int handMax = 4;
    public int handCnt = 0;
    private PlayerCardUI card;
    private GameObject PlayerCardUIScript;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void UpdateHandUI(PlayerCardSO chosen){
            handOrder[handCnt].SetActive(true);
            card = handOrder[handCnt].GetComponent<PlayerCardUI>();
            card.UpdateCardUI(chosen);
            handCnt++;
    }

}
