using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargets : MonoBehaviour
{
    [SerializeField] List<Participant> players = new List<Participant>();
    [SerializeField] List<Participant> monsters = new List<Participant>();
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OrganizeParticipants(List<Participant> data)
    {
        foreach (Participant participant in data)
        {
            (participant.GetTarget() == Target.player ? players : monsters).Add(participant);
        }
    }

    public List <Participant> GetRandomTarget(int nTargets, Target targetType)
    {
        List<Participant> targets = new List<Participant>();
        for (int i = 0; i < nTargets; i++)
        {
            int range = (targetType == Target.player ? players : monsters).Count;
            int choice = Random.Range(0, range);
            targets.Add(targetType == Target.player ? players[choice] : monsters[choice]);
        }
        return targets;
    }
}
