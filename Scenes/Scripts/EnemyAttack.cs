using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyAttack : ScriptableObject
{

    [SerializeField] EnemyBase enemy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void baseAttack(){
        enemy.baseAttack();
    }

    public void baseDefensek(){
        enemy.baseAttack();
    }
    public void specialAttack(){
        enemy.baseAttack();
    }
    public void specialAttack2(){
        enemy.baseAttack();
    }
    public void specialAttack3(){
        enemy.baseAttack();
    }
}
