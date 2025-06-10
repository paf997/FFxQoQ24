using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IntitiativeScale : MonoBehaviour
{
    [SerializeField] List<GameObject> inititaitveScalePositions = new List<GameObject>();
    [SerializeField] List<Participant> participantInitiativeAndIcon = new List<Participant>();
    [SerializeField] GameObject enemyCanvas;
    [SerializeField] List<GameObject> participantIcons = new List<GameObject>();
    [SerializeField] int iconPosition = 0;
    [SerializeField] int maxParticipants = 3;
    [SerializeField] Button nextRoundButton;

    // Start is called before the first frame update
    void Start()
    {
        nextRoundButton.interactable = false;
        AddEnemyActionAndInitiative();
    }

    public void AddParticipantInitiative(Participant data)
    {
        if (participantInitiativeAndIcon.Count < maxParticipants)
        { }
        else
        {
            ClearParticapants();
        }

        participantInitiativeAndIcon.Add(data);
        OrderParticipantsOnInittiativeScale();
        data.gameObject.SetActive(true);
    }

    public void ToggleNextRoundButtonActive()
    {
        nextRoundButton.interactable = !nextRoundButton.interactable;
        nextRoundButton.GetComponent<Image>().color =
        (nextRoundButton.interactable == true) ? Color.blue : Color.red;
    }

    public void NextRoundButton()
    {
        ClearParticapants();
        ToggleNextRoundButtonActive();
        AddEnemyActionAndInitiative();
    }

    public void OrderParticipantsOnInittiativeScale()
    {
        participantInitiativeAndIcon.Sort((a, b) => a.GetInitiative().CompareTo(b.GetInitiative()));
        int i = 0;
        foreach (Participant participant in participantInitiativeAndIcon)
        {
            RectTransform initiativeScalePos = participant.GetInitiativeIcon().GetComponent<RectTransform>();
            float newX = inititaitveScalePositions[i].GetComponent<RectTransform>().position.x;
            float newY = inititaitveScalePositions[i].GetComponent<RectTransform>().position.y;
            float newZ = inititaitveScalePositions[i].GetComponent<RectTransform>().position.z;
            i++;
            initiativeScalePos.position = new Vector3(newX, newY, newZ);
            /*string tempStr = $"x: {newX} + y: {newY} + z: {newZ} + i:{i}";
            Debug.Log(tempStr);*/
        }
        if (participantInitiativeAndIcon.Count == maxParticipants)
        {
            ToggleNextRoundButtonActive();
        }
    }

    public void AddEnemyActionAndInitiative()
    {
        Biome biome = enemyCanvas.GetComponent<Biome>();
        List<GameObject> enemies = new List<GameObject>();
        enemies = biome.GetRandomEncounter();
        foreach (GameObject enemy in enemies)
        {
            EnemyInfo enemyScript = enemy.GetComponent<EnemyInfo>();
            enemyScript.getRandomAbility();
            AddParticipantInitiative(enemyScript.GetParticipantScript());
        }
    }

    public void ClearParticapants()
    {
        if (participantInitiativeAndIcon.Count > 0)
        {
            for (int i = 0; i < maxParticipants; i++)
            {
                Participant participant = participantInitiativeAndIcon[i].GetComponent<Participant>();
                Debug.Log("participant iteration " + iconPosition);
                Button icon = participant.GetInitiativeIcon();
                icon.gameObject.SetActive(false);
                iconPosition++;
                if (participant.GetType() == typeof(CharacterScript))
                {
                    CharacterScript character = participant as CharacterScript;
                    character.GetPlayerBag().EndTurn();
                }
            }
            participantInitiativeAndIcon.Clear();
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
