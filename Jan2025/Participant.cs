using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target{ player1, enemy1, enemy2}

public class Participant : MonoBehaviour
{
    [SerializeField] int poisonDmg;
    public int att;
    [SerializeField] int baseAtt;
    public List <BattleAbility> conditions = new List<BattleAbility>(){};
     
    //[SerializeField] Participant participant;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDef(){

    }

    public void checkCurrentConditons(){

        for(int i = 0; i < conditions.Count; i++) {
            BattleAbility condition = conditions[i];
            int adj = condition.adjustment[i];
            if(condition.duration > 0){
                att = (baseAtt - adj);
                condition.duration --;
            }else{
                conditions.RemoveAt(i);
            }
        }
    }
}
