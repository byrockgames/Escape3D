using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    // Spawnlanip Hareket Edecek Objeler 
    public GameObject[] SpawnObjects;
    // SpawnBase
    public Transform[] SpawnBase;

    void Start()
    {
        InvokeRepeating(nameof(Spawn_Objects), 0.01f, 2f);
    }

    
    void Update()
    {
       

    }

    void Spawn_Objects()
    {
        int RandomEnemy = Random.Range(0, SpawnObjects.Length);
        int RandomSpawnBase = Random.Range(0, SpawnBase.Length);

        GameObject.Instantiate(SpawnObjects[RandomEnemy], SpawnBase[RandomSpawnBase].position , Quaternion.identity);
    
    }



}
