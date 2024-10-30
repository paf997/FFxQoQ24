using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
    public MonsterStats stats;
    int baseDMG = 2;
    int baseDFS = 2;
    int randomAction;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<MonsterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void basicAttack(GameObject target){
        Debug.Log("Goblin Basic Attack. Goblin deals " + (3*baseDMG) + "DMG");
        //target.adjustHP(3*baseDMG);
    }
    public void basicDefense(){
        Debug.Log("Goblin Basic Defense. Goblin  generates" + (3*baseDFS) + "DFS");
    }
    public void poisonAttack(){
        Debug.Log("Goblin Poison Attack. Goblin deals " + "1 " + "Poison");
    }
    public void powerAttack(){
        Debug.Log("Goblin Power Attack. Goblin deals " + (5*baseDMG) + "DMG");
    }

    private void action(int nActions){
        int action = Random.Range(0,nActions);
            /*switch(action){
        case 0:
            basicAttack();
            basicAttack();
            //Debug.Log("white");
            break;
        case 1:
            basicDefense();
            basicAttack();
            break;
        case 2:
            basicDefense();
            basicDefense();
            poisonAttack();
            break;
        case 3:
            powerAttack();
            basicDefense();
            poisonAttack();
            break;
        case 4:
            powerAttack();
            basicDefense();
            basicAttack();
            break;
        default:
            Debug.Log("Nothing Happens");
            break;
        }*/
    }
}


