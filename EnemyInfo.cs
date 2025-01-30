using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : Participant
{
    public int block;
    public int pierce;
    public int heal;
    [SerializeField] Sprite enemySprite;
    [SerializeField] List <BattleAbility> abilityList;
    public BattleAbility ability; 


    // Start is called before the first frame update
    void Start()
    {
       /* ability = abilityList[0];
        Debug.Log(" Ability: " + ability.adjustment[i]);*/
    }

    public BattleAbility getRandomAbility(){
        int total = 0;
        Debug.Log("Ability List Count " + abilityList.Count);
        for (int i = 0; i < abilityList.Count; i++){
            ability = abilityList[i];
            total += ability.probability;
            //Debug.Log("Probability = " + total);
        }
        int index = Random.Range(0, abilityList.Count);
        return abilityList[index];
    }
}
