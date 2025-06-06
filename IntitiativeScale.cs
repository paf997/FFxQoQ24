using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IntitiativeScale : MonoBehaviour
{
    [SerializeField] List<GameObject> inititaitveScalePositions = new List<GameObject>();
    [SerializeField] List<CharacterScript> participantInitiativeAndIcon = new List<CharacterScript>();
    [SerializeField] List<GameObject> participantIcons = new List<GameObject>();
    [SerializeField] int iconPosition = 0;
    [SerializeField] int participants;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddParticipantInitiative(CharacterScript data)
    {
        participantInitiativeAndIcon.Add(data);
        OrderParticipantsOnInittiativeScale();
        participants = participantIcons.Count;
    }

    public void OrderParticipantsOnInittiativeScale()
    {
        participantInitiativeAndIcon.Sort((a, b) => a.GetInitiative().CompareTo(b.GetInitiative()));
        int i = 0;
        foreach (CharacterScript participant in participantInitiativeAndIcon)
        {
            RectTransform initiativeScalePos = participant.GetInitiativeIcon().GetComponent<RectTransform>();
            float newX = inititaitveScalePositions[i].GetComponent<RectTransform>().position.x;
            float newY = inititaitveScalePositions[i].GetComponent<RectTransform>().position.y;
            float newZ = inititaitveScalePositions[i].GetComponent<RectTransform>().position.z;
            i++;
            initiativeScalePos.position = new Vector3(newX, newY, newZ);
            string tempStr = $"x: {newX} + y: {newY} + z: {newZ} + i:{i}";
            Debug.Log(tempStr);
        }
    }

    public void ClearParticapants()
    {
        if (participantIcons.Count > 0 && iconPosition < participantIcons.Count)
        {
            Button icon = participantInitiativeAndIcon[iconPosition].GetInitiativeIcon();
            icon.gameObject.SetActive(false);
            iconPosition++;
        }
        else
        {
            Debug.Log("NO participants");
            iconPosition = 0;
        }
        /*foreach (CharacterScript participant in participantInitiativeAndIcon)
        {
            Button icon = participant.GetInitiativeIcon();
            icon.gameObject.SetActive(false);
        
        }*/

    }

  /*Debug.Log("placeTokenOnATB");
                RectTransform posATB = token.GetComponent<RectTransform>();
                //Debug.Log("Transform token" + token.name);
                adjustInitiative(token.getTokenValue());
                float newX = ATBList[initiative].GetComponent<RectTransform>().position.x;
                float newY = ATBList[initiative].GetComponent<RectTransform>().position.y;
                float newZ = ATBList[initiative].GetComponent<RectTransform>().position.z;
                // Debug.Log("Transform  ATB" + ATBList[0].GetComponent<RectTransform>());
                posATB.position = new Vector3(newX, newY, newZ);
                //posATB.Translate(newX, newY, newZ);*/
}
