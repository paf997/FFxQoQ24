using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BiomeData", menuName = "Game/BiomeData", order = 1)]
public class BiomeData : ScriptableObject
{
    public List<GameObject> encounters = new List<GameObject>();
    public GameObject tempEnemyPrefab;

    public List<GameObject> GetList()
    {
        return encounters;
    }
}
