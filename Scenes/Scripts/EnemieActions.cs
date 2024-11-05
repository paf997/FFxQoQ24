using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyActions : ScriptableObject
{

    private EnemyActions action;
    [SerializeField] int dmg;
    [SerializeField] int nAttacks;
    [SerializeField] int def;
    [SerializeField] string name;
    [SerializeField] int initiative;
   // Start is called before the first frame update
    void Start()
    {
        
    }

}
