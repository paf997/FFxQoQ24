using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenDiscardArea : MonoBehaviour{
[SerializeField] List <GameObject> DiscardedTokensList = new List<GameObject>();
[SerializeField] RectTransform tokenDiscardArea;

    public void addTokenToDiscardArea(GameObject token){
        DiscardedTokensList.Add(token);
        RectTransform currnetTokenPos = token.GetComponent<RectTransform>();
        currnetTokenPos.position = new Vector3 (tokenDiscardArea.position.x,tokenDiscardArea.position.y,tokenDiscardArea.position.z );
    }

}
