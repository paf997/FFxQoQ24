using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [SerializeField] List<GameObject> biome = new List<GameObject>();
    [SerializeField] BiomeData biomeData;
    [SerializeField] GameObject tempEnemyPrefab;
    [SerializeField] Transform tempTransform;

    // Start is called before the first frame update
    void Start()
    {
        biome = biomeData.encounters;
        Debug.Log("Random Enoucnter === " + GetRandomEncounter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> GetList()
    {
        return biome;
    }

    public void FindItem()
    {
        //return index
    }

    public List<GameObject> GetRandomEncounter()
    {
        if (biome.Count > 0)
        {
            int choice = 0;
            List<GameObject> randomEncounter = new List<GameObject>();
            for (int i = 0; i < 3; i++)
            {
                choice = Random.Range(0, biome.Count);
                GameObject newEnemy = Instantiate(tempEnemyPrefab, tempTransform.position, Quaternion.identity, tempTransform);
                randomEncounter.Add(newEnemy);
            }

            return randomEncounter;
        }
        return null;
    }
}
